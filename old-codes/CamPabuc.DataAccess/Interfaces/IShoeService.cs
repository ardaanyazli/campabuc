using CamPabuc.Model.Entity;
using CamPabuc.Model.ViewModel;
using System.Drawing;

namespace CamPabuc.DataAccess.Interfaces
{
    public interface IShoeService : IBaseService<Shoe,ShoeVM>
    {
        public Task<Image> CreateBarcodeImage(string barcodeString);
        public Task<bool> BulkInsert(params Shoe[] shoes);
        public Task<IEnumerable<ShoeVM>> Search(string searchText);
        public Shoe MakeDbModel(ShoeVM shoe);
    }
}
