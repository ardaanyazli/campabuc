using CamPabuc.DataAccess.Interfaces;
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
using CamPabuc.Model.Entity;

namespace CamPabuc.UI
{
    public partial class OptionDetailForm : Form
    {
        private readonly IShoeMaterialService _shoeMaterialService;
        private readonly IShoeColorService _shoeColorService;
        private readonly IShoeCategoryService _shoeCategoryService;
        public readonly string selectedOption;

        public OptionDetailForm()
        {
            InitializeComponent();
        }

        public OptionDetailForm(string optionName)
        {
            InitializeComponent();

            selectedOption = optionName;
            string titlePlaceHolder = string.Empty;

            switch (selectedOption)
            {
                case "ShoeMaterial":
                    _shoeMaterialService = new ShoeMaterialService();
                    titlePlaceHolder = "Materyal";
                    break;
                case "ShoeColor":
                    _shoeColorService = new ShoeColorService();
                    titlePlaceHolder = "Renk";
                    break;
                case "ShoeCategory":
                    _shoeCategoryService = new ShoeCategoryService();
                    titlePlaceHolder = "Kategori";
                    break;
            }

            this.Text = $"Yeni {titlePlaceHolder} Ekle";
            lblOptionName.Text = titlePlaceHolder;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (selectedOption)
            {
                case "ShoeMaterial":
                    _shoeMaterialService.Create(new ShoeMaterial() { Name = txtOptionValue.Text }).Wait();
                    break;
                case "ShoeColor":
                    _shoeColorService.Create(new ShoeColor() { Name = txtOptionValue.Text }).Wait();
                    
                    break;
                case "ShoeCategory":
                    _shoeCategoryService.Create( new ShoeCategory() { Name = txtOptionValue.Text }).Wait();
                    break;
            }

            this.Close();
        }

        private void OptionDetailForm_Load(object sender, EventArgs e)
        {

        }
    }
}
