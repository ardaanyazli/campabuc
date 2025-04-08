using CamPabuc.DataAccess.Interfaces;
using CamPabuc.Model.Entity;
using CamPabuc.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamPabuc.DataAccess
{
    public class SalesService : ISalesService
    {
        private const string BASE_QUERY = @$"
SELECT 
ShoeBarcode
,SalePrice
FROM Shoe 
";
        public Tuple<string, decimal> GetByBarcode(string barcode)
        {
            string query = BASE_QUERY + " WHERE ShoeBarcode = @Barcode";
            var item = DbExecutor.QueryFirst<Tuple<string, decimal>>(query, new { Barcode = barcode, });

            return item;
        }

        public void SaveSale(SaleVM sale)
        {
            DbExecutor.Insert("Sales", sale.Item);
            DbExecutor.Insert("SaleDetails", sale.SaleDetails);

            foreach (var item in sale.SaleDetails)
            {
                DbExecutor.Execute("UPDATE Shoes SET Quantity=Quantity-@qty WHERE ShoeBarcode = @Barcode", new { qty = item.Quantity, Barcode = item.Barcode });
            }
        }
    }
}
