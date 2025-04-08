using CamPabuc.DataAccess;
using CamPabuc.DataAccess.Interfaces;
using CamPabuc.Model.Entity;
using CamPabuc.Model.ViewModel;
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
    public partial class ShoeSalesForm : Form
    {
        private readonly decimal dollarParity;
        private readonly decimal euroParity;
        //private readonly IShoeService _shoeService;
        private readonly ISalesService _salesService;
        private decimal salesTotal;
        private SaleVM currentSale;// sale item taht has all details

        public ShoeSalesForm()
        {
            InitializeComponent();
            _salesService = new SalesService();
            currentSale = new SaleVM();
            salesTotal = 0;
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Length >= 5)
            {
                btnAdd_Click(btnAdd, new EventArgs());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Length >= 5)
            {
                AddToSalesList(txtBarcode.Text);
            }
        }

        private void btnShowTRY_Click(object sender, EventArgs e)
        {
            ShowTotalAsCurrency("TRY");
        }

        private void btnShowDollar_Click(object sender, EventArgs e)
        {
            ShowTotalAsCurrency("USD");
        }

        private void btnShowEuro_Click(object sender, EventArgs e)
        {
            ShowTotalAsCurrency("EUR");
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            //Record sale to history
            currentSale.Item.SaleDate = DateTime.Now;
            _salesService.SaveSale(currentSale);
            ClearForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void AddToSalesList(string barcode)
        {
            var soldShoe = _salesService.GetByBarcode(barcode);
            decimal subTotal = nmrQty.Value * soldShoe.Item2;
            lstSales.Items.Add($"{soldShoe.Item1}-{soldShoe.Item2}x{nmrQty.Value}-{subTotal}");
            currentSale.SaleDetails.Add(new SaleDetail() { Barcode = soldShoe.Item1, Quantity = (int)nmrQty.Value, Price = soldShoe.Item2 });
            salesTotal += subTotal;
        }

        private void ShowTotalAsCurrency(string currency)
        {
            string curSymbol = "₺";
            decimal total = salesTotal;
            currentSale.Item.SaleCurrency = 1;

            switch (currency)
            {
                case "USD":
                    curSymbol = "$";
                    total = salesTotal * dollarParity;
                    currentSale.Item.SaleCurrency = 2;
                    break;
                case "EUR":
                    curSymbol = "€";
                    total = salesTotal * euroParity;
                    currentSale.Item.SaleCurrency = 3;
                    break;
            }

            currentSale.Item.Total = total;
            lblSalesTotal.Text = $"{total} {curSymbol}";
        }

        private void ClearForm()
        {
            lstSales.Items.Clear();
            currentSale = new SaleVM();
        }
    }
}
