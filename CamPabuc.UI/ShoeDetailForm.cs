using CamPabuc.DataAccess;
using CamPabuc.DataAccess.Interfaces;
using CamPabuc.Model.Entity;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
using CamPabuc.Model.ViewModel;
//using ZXing;
//using ZXing.Common;
//using ZXing.Rendering;

namespace CamPabuc.UI
{
    public partial class ShoeDetailForm : Form
    {
        private readonly IShoeService _shoeService;
        private readonly IShoeColorService _shoeColorService;
        private readonly IShoeMaterialService _shoeMaterialService;
        private readonly IShoeGenreService _shoeGenreService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IShoeCategoryService _shoeCategoryService;
        private readonly bool _editMode = true;
        private Shoe shoeEntity = new();
        private readonly ShoeVM shoeModel = new();
        private OptionDetailForm optionDetailForm;

        private bool _bulkInsert = false;
        public ShoeDetailForm()
        {
            _shoeService = new ShoeService();
            _shoeColorService = new ShoeColorService();
            _shoeMaterialService = new ShoeMaterialService();
            _manufacturerService = new ManufacturerService();
            _shoeCategoryService = new ShoeCategoryService();
            _shoeGenreService = new ShoeGenreService();

            InitializeComponent();
        }
        public ShoeDetailForm(int? shoeId, bool editMode)
        {
            _shoeService = new ShoeService();
            _shoeColorService = new ShoeColorService();
            _shoeMaterialService = new ShoeMaterialService();
            _manufacturerService = new ManufacturerService();
            _shoeCategoryService = new ShoeCategoryService();
            _shoeGenreService = new ShoeGenreService();

            InitializeComponent();
            _editMode = editMode;

            if (shoeId.HasValue)
            {
                shoeModel = _shoeService.GetById(shoeId.Value).Result;
            }
        }

        private void ShoeDetailForm_Load(object sender, EventArgs e)
        {
            PrepareLists();
            PrepareShoeModel();

            if (!_editMode)
            {
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Enabled = false;
                    }
                    else if (item is Button || item is CheckBox)
                    {
                        item.Visible = false;
                    }
                }
            }
        }
        private void PrepareLists()
        {
            var list = new Task[] {
            GetShoeColors(),
            GetShoeMaterials(),
            GetManufacturers(),
            GetShoeGenre(),
            GetShoeCategories()
            };

            Task.WaitAll(list);
        }

        private async Task GetShoeColors()
        {
            var list = await _shoeColorService.GetAll();

            cmbColor.DisplayMember = "Name";
            cmbColor.ValueMember = "Id";
            cmbColor.DataSource = list;
        }

        private async Task GetShoeMaterials()
        {
            var list = await _shoeMaterialService.GetAll();

            cmbMaterial.DisplayMember = "Name";
            cmbMaterial.ValueMember = "Id";
            cmbMaterial.DataSource = list;
        }

        private async Task GetShoeCategories()
        {
            var list = await _shoeCategoryService.GetAll();

            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
            cmbCategory.DataSource = list;
        }

        private async Task GetShoeGenre()
        {
            var list = await _shoeGenreService.GetAll();

            cmbGenre.DisplayMember = "Name";
            cmbGenre.ValueMember = "Id";
            cmbGenre.DataSource = list;
        }

        private async Task GetManufacturers()
        {
            var list = await _manufacturerService.GetAll();

            cmbManufacturer.DisplayMember = "FirmName";
            cmbManufacturer.ValueMember = "Id";
            cmbManufacturer.DataSource = list;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            UpdateShoeModel();

            if (shoeModel.Id != 0)
            {
                _shoeService.Update(shoeEntity).Wait();
            }
            else
            {
                if (_bulkInsert)
                {
                    string[] values = new string[2];

                    switch (cmbGenre.Text)
                    {
                        case "ZENNE":
                            values = Settings.Instance.WomenSizeRange.Split('-');
                            break;
                        case "MERDANE":
                            values = Settings.Instance.MenSizeRange.Split('-');
                            break;
                        case "ÇOCUK":
                            values = Settings.Instance.ChildSizeRange.Split('-');
                            break;
                    }
                    IEnumerable<int> doubleQty = Settings.Instance.DoubleQtySizeList.Split(',').Select(x => int.Parse(x));
                    int start = int.Parse(values[0]);
                    int finish = int.Parse(values[1]);
                    List<Shoe> bulkModels = new List<Shoe>();
                    shoeEntity = _shoeService.MakeDbModel(shoeModel);
                    for (int i = start; i <= finish; i++)
                    {
                        var bulkModel = (Shoe)shoeEntity.Clone();
                        bulkModel.Size = i;
                        bulkModel.Quantity *= doubleQty.Contains(i) ? 2 : 1;
                        bulkModel.ShoeBarcode = GenerateBarcode(shoeEntity);
                        bulkModels.Add(bulkModel);
                    }

                    _shoeService.BulkInsert(bulkModels.ToArray()).Wait();
                }
                else
                {
                    _shoeService.Create(shoeEntity).Wait();
                }
            }

            btnSave.Enabled = true;
        }

        private string GenerateBarcode(Shoe shoeModel)
        {
            return $"{shoeModel.Manufacturer}{shoeModel.QualityCode}{shoeModel.ShoeColor}{shoeModel.Size}";
        }

        private void PrepareShoeModel()
        {
            cmbGenre.SelectedValue = shoeModel.GenreId;
            cmbManufacturer.SelectedValue = shoeModel.ManufacturerId;
            nmrPrice.Value = shoeModel.Price;
            txtQualityCode.Text = shoeModel.QualityCode;
            nmrQuantity.Value = shoeModel.Quantity.GetValueOrDefault(0);
            nmrSalePrice.Value = shoeModel.SalePrice;
            cmbCategory.SelectedValue = shoeModel.ShoeCategoryId;
            cmbColor.SelectedValue = shoeModel.ShoeColorId;
            txtDetails.Text = shoeModel.ShoeDetails;
            cmbMaterial.SelectedValue = shoeModel.ShoeMaterialId;
            nmrSize.Value = shoeModel.Size.GetValueOrDefault(0);
            lblShoeBarcode.Text = shoeModel.ShoeBarcode;
        }

        private void UpdateShoeModel()
        {
            shoeModel.GenreId = (int)cmbGenre.SelectedValue;
            shoeModel.ManufacturerId = (int)cmbManufacturer.SelectedValue;
            shoeModel.Price = nmrPrice.Value;
            shoeModel.QualityCode = txtQualityCode.Text;
            shoeModel.Quantity = (int)nmrQuantity.Value;
            shoeModel.SalePrice = nmrSalePrice.Value;
            shoeModel.ShoeCategoryId = (int)cmbCategory.SelectedValue;
            shoeModel.ShoeColorId = (int)cmbColor.SelectedValue;
            shoeModel.ShoeDetails = txtDetails.Text;
            shoeModel.ShoeMaterialId = (int)cmbMaterial.SelectedValue;
            shoeModel.Size = (int)nmrSize.Value;
            shoeModel.ShoeBarcode = GenerateBarcode(shoeEntity);
        }

        private void btnAddManufacturer_Click(object sender, EventArgs e)
        {
            ManufacturerDetailForm form = new ManufacturerDetailForm();
            form.ShowDialog();
            form.FormClosed += RefreshList;

            
        }

        private void RefreshList(object? sender, FormClosedEventArgs e)
        {
            if (sender != null)
            {
                if (sender is ManufacturerDetailForm)
                {
                    GetManufacturers().Wait();
                }
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            CreateOption("ShoeCategory");
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            //optionDetailForm = new OptionDetailForm("ShoeMaterial");
            //optionDetailForm.ShowDialog();
            //optionDetailForm.FormClosed += RefreshList;
            CreateOption("ShoeMaterial");
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            //optionDetailForm = new OptionDetailForm("ShoeColor");
            //optionDetailForm.ShowDialog();
            //optionDetailForm.FormClosed += RefreshList;
            CreateOption("ShoeColor");
        }

        private void CreateOption(string optionName)
        {
            optionDetailForm = new OptionDetailForm(optionName);

            if (optionDetailForm.ShowDialog() == DialogResult.OK && optionDetailForm.selectedOption.Equals(optionName, StringComparison.OrdinalIgnoreCase))
            {
                switch (optionName)
                {
                    case "ShoeMaterial":
                        GetShoeMaterials().Wait();
                        break;
                    case "ShoeColor":
                        GetShoeColors().Wait();
                        break;
                    case "ShoeCategory":
                        GetShoeCategories().Wait();
                        break;
                }
            }
        }

        private void btnGenerateBarcode_Click(object sender, EventArgs e)
        {
            shoeModel.ShoeBarcode = GenerateBarcode(shoeEntity);
            lblShoeBarcode.Text = shoeModel.ShoeBarcode;
            var btn = new Button() { Size = new Size(0, 0) };
            btn.Click += Btn_Click;

            var frm = new Form()
            {
                AutoSize = true,
                FormBorderStyle = FormBorderStyle.None,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                Size = new Size(400, 100),
            };

            frm.Controls.Add(btn);

            frm.CancelButton = btn;
            frm.BackgroundImage = _shoeService.CreateBarcodeImage(shoeModel.ShoeBarcode).Result;
            frm.BackgroundImageLayout = ImageLayout.Stretch;

            frm.Show();
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            (((Button)sender).Parent as Form).Close();
        }

        private void cbSetStock_CheckedChanged(object sender, EventArgs e)
        {
            _bulkInsert = cbSetStock.Checked;
            nmrSize.Enabled = !cbSetStock.Checked;
        }
    }
}
