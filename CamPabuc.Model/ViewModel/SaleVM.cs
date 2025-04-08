using CamPabuc.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamPabuc.Model.ViewModel
{
    public class SaleVM
    {
        public SaleVM()
        {
            Item = new Sale();
            SaleDetails = new List<SaleDetail>();
        }

        public ICollection<SaleDetail> SaleDetails { get; private set; }

        public Sale Item { get; private set; }
    }
}
