using CamPabuc.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamPabuc.Model.Entity
{
    public class SaleDetail : IEntity
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
