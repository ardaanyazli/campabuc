using campabuc.model.interfaces;

namespace campabuc.model;

public class Shoe : IHasCreateDate, IHasDeleteDate, IHasUUID
{
    public required string Id { get; set; }
    public byte Category { get; set; }
    public long Material { get; set; }
    public long Color { get; set; }
    public long Size { get; set; }
    public long Manufacturer { get; set; }
    public decimal Price { get; set; }
    public long Inventory { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? Barcode { get; set; }
    public string? ImageUrl { get; set; }
}
