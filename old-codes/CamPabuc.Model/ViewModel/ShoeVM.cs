using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamPabuc.Model.ViewModel
{
    public class ShoeVM
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string? Genre { get; set; }
        public int ManufacturerId { get; set; }
        public string? Manufacturer { get; set; }
        public string? QualityCode { get; set; }
        public int ShoeCategoryId { get; set; }
        public string? ShoeCategory { get; set; }
        public int ShoeMaterialId { get; set; }
        public string? ShoeMaterial { get; set; }
        public int ShoeColorId { get; set; }
        public string? ShoeColor { get; set; }
        public int? Size { get; set; }
        public int? Quantity { get; set; }
        public string? ShoeDetails { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public string? ShoeBarcode { get; set; }
    }
}
