using CamPabuc.Model.Interfaces;

namespace CamPabuc.Model.Entity
{
    public class Shoe : IEntity, ICloneable
    {
        public int Id { get; set; }
        public int Genre { get; set; }
        public int Manufacturer { get; set; }
        public string? QualityCode { get; set; }
        public int ShoeCategory { get; set; }
        public int ShoeColor { get; set; }
        public int ShoeMaterial { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public string? ShoeDetails { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public string? ShoeBarcode { get; set; }

        public object Clone()
        {
            return new Shoe()
            {
                Id = Id,
                Genre = Genre,
                Manufacturer = Manufacturer,
                ShoeMaterial = ShoeMaterial,
                Size = Size,
                Quantity = Quantity,
                Price = Price,
                SalePrice = SalePrice,
                QualityCode = QualityCode,
                ShoeCategory = ShoeCategory,
                ShoeColor = ShoeColor,
                ShoeDetails = ShoeDetails,
            };
        }
    }
}