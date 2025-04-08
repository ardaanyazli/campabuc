using CamPabuc.DataAccess;
using CamPabuc.DataAccess.Interfaces;
using CamPabuc.Model.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using CamPabuc.Model.ViewModel;

namespace CamPabuc.UI
{
    public partial class ShoesForm : Form
    {
        private readonly IShoeService _shoeService;
        private List<Tuple<string, Image>> barcodeImages = new List<Tuple<string, Image>>();

        public ShoesForm()
        {
            InitializeComponent();

            _shoeService = new ShoeService();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var detailForm = new ShoeDetailForm();

            detailForm.ShowDialog();
        }

        private void ShoesForm_Load(object sender, EventArgs e)
        {
            FillList(GetAllShoes());
        }

        private IEnumerable<ShoeVM> GetAllShoes()
        {
            return _shoeService.GetAll().Result;
        }

        private void FillList(IEnumerable<ShoeVM> list)
        {
            lvShoes.Items.Clear();

            foreach (var item in list)
            {
                var lvi = new ListViewItem(item.ShoeBarcode);
                lvi.Tag = item;
                lvi.SubItems.Add(item.Genre.ToString());
                lvi.SubItems.Add(item.Size.ToString());
                lvi.SubItems.Add(item.Quantity.ToString());
                lvi.SubItems.Add(item.ShoeColor.ToString());
                lvi.SubItems.Add(item.ShoeCategory.ToString());
                lvi.SubItems.Add(item.ShoeMaterial.ToString());
                lvi.SubItems.Add(item.SalePrice.ToString("N2"));
                lvi.SubItems.Add(item.Manufacturer);

                lvShoes.Items.Add(lvi);
            }
        }

        private void lvShoes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = lvShoes.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item != null)
            {
                var df = new ShoeDetailForm(((ShoeVM)item.Tag).Id, true);
                df.ShowDialog();
            }
            else
            {
                this.lvShoes.SelectedItems.Clear();
                MessageBox.Show("No Item is selected");
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetBarcodes(lvShoes.SelectedItems);
            ChangePrintButton();
            printPreviewDialog1.ShowDialog();
        }

        private void ChangePrintButton()
        {
            ToolStripButton b = new ToolStripButton();
            b.Image = ((ToolStrip)(printPreviewDialog1.Controls[1])).ImageList.Images[0];
            b.DisplayStyle = ToolStripItemDisplayStyle.Image;
            b.Click += printToolStripMenuItem_Click;

            ((ToolStrip)(printPreviewDialog1.Controls[1])).Items.RemoveAt(0);
            ((ToolStrip)(printPreviewDialog1.Controls[1])).Items.Insert(0, b);
        }

        private void GetBarcodes(ListView.SelectedListViewItemCollection selectedItems)
        {
            barcodeImages.Clear();
            foreach (ListViewItem item in selectedItems)
            {
                for (int i = 0; i < ((ShoeVM)item.Tag).Quantity; i++)
                {
                    Image barcodeImage = _shoeService.CreateBarcodeImage(item.Text).Result;

                    barcodeImages.Add(new Tuple<string, Image>(item.Text, barcodeImage));
                }
            }
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (barcodeImages.Count > 0)
            {
                int bcPerLine = 3;
                byte barcodePerPage = 36;
                int count = 0;
                int startX = 5;
                int startY = 5;
                byte numBc = 0;
                Font printFont = new Font("Arial", 10.0f);

                for (int i = 0; i < barcodeImages.Count; i++)
                {
                    Bitmap bmp = new Bitmap(barcodeImages[i].Item2);
                    int x3 = startX;
                    int y3 = startY + bmp.Height + 5;

                    e.Graphics.DrawImage(bmp, startX, startY);
                    e.Graphics.DrawString(barcodeImages[i].Item1, printFont, Brushes.Black, x3, y3);
                    numBc++;

                    if (numBc < bcPerLine)
                    {
                        startX += bmp.Width + 50;
                    }
                    else
                    {
                        startX = 5;
                        startY += bmp.Height + 30; // space between 2 barcode in vertical (upper left). you have to adjust)
                        numBc = 0;
                    }

                    count++;

                    if (count == barcodePerPage)
                    {
                        e.HasMorePages = true;
                        barcodeImages.RemoveRange(0, count);

                        return;
                    }
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var list = string.IsNullOrWhiteSpace(textBox1.Text) ? GetAllShoes() : _shoeService.Search(textBox1.Text.ToUpperInvariant()).Result;
            FillList(list);
        }
    }
}
