using CamPabuc.Model.ViewModel;

namespace CamPabuc.DataAccess.Interfaces
{
    public interface ISalesService
    {
        Tuple<string, decimal> GetByBarcode(string barcode);

        void SaveSale(SaleVM sale);
    }
}
