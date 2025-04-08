using CamPabuc.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamPabuc.Model.Entity
{
    public class Sale : IEntity
    {
        public int Id { get; set; }
        public int SaleCurrency { get; set; }
        public decimal Total { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
