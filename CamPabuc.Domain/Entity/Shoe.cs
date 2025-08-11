namespace CamPabuc.Domain.Entity;
using CamPabuc.Domain.Enums;
public class Shoe : BaseEntity, IHasIntKey
{
    public int Id { get; set; }
    public string Barcode { get; set; } = default!;
    public ShoeGender Gender { get; set; }
    public decimal Price { get; set; } = default!;
    public string Color { get; set; } = default!;
    public string? Description { get; set; }
    public int Stock { get; set; } = default!;
    public Guid? ManufacturerId { get; set; }
    public Manufacturer? Manufacturer { get; set; }
    public Guid? ShoeCategoryId { get; set; }
    public ShoeCategory? ShoeCategory { get; set; }
}
