using CamPabuc.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamPabuc.UI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnUpdateSettings_Click(object sender, EventArgs e)
        {
            Settings.Instance.BarcodeWidth = int.Parse(txtBarcodeWidth.Text);
            Settings.Instance.BarcodeHeight = int.Parse(txtBarcodeHeight.Text);
            Settings.Instance.ChildSizeRange = txtChildSizeRange.Text;
            Settings.Instance.WomenSizeRange = txtWomenSizeRange.Text;
            Settings.Instance.MenSizeRange = txtWomenSizeRange.Text;
            Settings.Instance.DoubleQtySizeList= txtDoubleQty.Text;

            Settings.UpdateSettings();
            this.Close();
        }
    }
}
