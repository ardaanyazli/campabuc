using BarcodeLib;
using CamPabuc.DataAccess.Interfaces;
using CamPabuc.Model.Entity;
using CamPabuc.Model.Interfaces;
using CamPabuc.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamPabuc.DataAccess
{
    public class ShoeService : IShoeService
    {
        private const string TABLE = "Shoe";
        private const string BASE_QUERY = $@"
SELECT s.Id
,s.Genre as GenreId
,sg.Name AS Genre
,s.Manufacturer AS ManufacturerId
,m.FirmName AS Manufacturer
,s.QualityCode
,s.ShoeCategory AS ShoeCategoryId
,scat.Name AS ShoeCategory
,s.ShoeMaterial AS ShoeMaterialId
,smat.Name AS ShoeMaterial
,s.ShoeColor AS ShoeColorId
,scol.Name AS ShoeColor
,s.Size
,s.Quantity
,s.ShoeDetails
,s.Price
,s.SalePrice
,s.ShoeBarcode
FROM Shoe s 
INNER JOIN Manufacturer m ON s.Manufacturer = m.Id
INNER JOIN ShoeGenre sg ON s.Genre= sg.Id
INNER JOIN ShoeCategory scat ON s.ShoeCategory= scat.Id
INNER JOIN ShoeMaterial smat ON s.ShoeMaterial= smat.Id
INNER JOIN ShoeColor scol ON s.ShoeColor= scol.Id";

        public Task<bool> BulkInsert(params Shoe[] shoes)
        {
            return Task.FromResult(DbExecutor.BulkInsert(TABLE, shoes));
        }

        public Task<bool> Create(Shoe model)
        {
            return Task.FromResult(DbExecutor.Insert(TABLE, model));
        }

        public Task<Image> CreateBarcodeImage(string barcodeString)
        {
            return Task.FromResult(new Barcode().Encode(TYPE.CODE128, barcodeString, Color.Black, Color.White, 160, 50));
        }

        public Task<bool> Delete(int Id)
        {
            return Task.FromResult(DbExecutor.Delete(TABLE, Id));
        }

        public Task<IEnumerable<ShoeVM>> GetAll()
        {

            IEnumerable<ShoeVM> shoeList = DbExecutor.QueryList<ShoeVM>(BASE_QUERY);

            return Task.FromResult(shoeList);
        }

        public Task<IEnumerable<ShoeVM>> GetByFilter(Func<Shoe, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ShoeVM> GetById(int id)
        {
            var query = BASE_QUERY + " WHERE s.Id=@Id";
            var shoe = DbExecutor.QueryFirst<ShoeVM>(query, new { Id = id });
            return Task.FromResult(shoe);
        }

        public Task<IEnumerable<ShoeVM>> Search(string searchText)
        {
            var searchQuery = BASE_QUERY + @" 
WHERE ShoeBarcode like @barcode OR 
sg.Name like @genre OR
m.FirmName like @manufacturer OR 
scol.Name like @color OR 
smat.Name like @material OR 
scat.Name like @category;";

            var list = DbExecutor.QueryList<ShoeVM>(searchQuery, new
            {
                barcode = $"%{searchText}%",
                genre= $"%{searchText}%",
                manufacturer = $"%{searchText}%",
                color = $"%{searchText}%",
                material = $"%{searchText}%",
                category = $"%{searchText}%"
            });

            return Task.FromResult(list);
        }

        public Task<bool> Update(Shoe model)
        {
            return Task.FromResult(DbExecutor.Update(TABLE, model));
        }

        public Shoe MakeDbModel(ShoeVM shoe)
        {
            var model = new Shoe()
            {
                Id = shoe.Id,
                ShoeColor = shoe.ShoeColorId,
                Genre = shoe.GenreId,
                ShoeBarcode = shoe.ShoeBarcode,
                Manufacturer = shoe.ManufacturerId,
                QualityCode = shoe.QualityCode,
                Price = shoe.Price,
                Quantity = shoe.Quantity.GetValueOrDefault(0),
                SalePrice = shoe.SalePrice,
                ShoeCategory = shoe.ShoeCategoryId,
                ShoeDetails = shoe.ShoeDetails,
                ShoeMaterial = shoe.ShoeMaterialId,
                Size = shoe.Size.GetValueOrDefault(0)
            };

            return model;
        }

    }
}
