using CamPabuc.DataAccess;
using CamPabuc.DataAccess.Interfaces;
using CamPabuc.Model.Entity;
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
    public partial class ManufacturerDetailForm : Form
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly bool _editMode = true;
        private readonly Manufacturer _model = new();

        public ManufacturerDetailForm()
        {
            InitializeComponent();
            _manufacturerService = new ManufacturerService();
        }

        public ManufacturerDetailForm(int manufacturerId, bool editMode)
        {
            _manufacturerService = new ManufacturerService();
            editMode = _editMode;
            _model = _manufacturerService.GetById(manufacturerId).Result;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateModelData();

            if (_model.Id != 0)
            {
                _manufacturerService.Update(_model);
            }
            else
            {
                _manufacturerService.Create(_model);
            }
        }

        private void ManufacturerDetailForm_Load(object sender, EventArgs e)
        {
            PrepareModelData();
            if (!_editMode)
            {
                foreach (Control control in this.Controls)
                {
                    if (control is TextBox)
                    {
                        control.Enabled = false;
                    }

                    if (control is Button)
                    {
                        control.Visible = false;
                    }
                }
            }
        }

        private void PrepareModelData()
        {
            txtFirmName.Text = _model.FirmName;
            txtContact.Text = _model.Contact;
            mtxtPhone.Text = _model.PhoneNumber;
            txtAddress.Text = _model.Address;
        }

        private void UpdateModelData()
        {
            _model.FirmName = txtFirmName.Text;
            _model.Contact = txtContact.Text;
            _model.PhoneNumber = mtxtPhone.Text;
            _model.Address = txtAddress.Text;
        }
    }
}
