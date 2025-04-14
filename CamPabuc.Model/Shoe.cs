using campabuc.model.interfaces;

namespace campabuc.model;

public class Shoe : IHasCreateDate, IHasDeleteDate
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? Barcode { get; set; }
    public decimal Price { get; set; }
    public decimal SalePrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
