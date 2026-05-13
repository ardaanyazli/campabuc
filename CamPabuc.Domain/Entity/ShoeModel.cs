namespace CamPabuc.Domain.Entity;
using CamPabuc.Domain.Enums;

public class ShoeModel : BaseEntity, IHasIntKey
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Brand { get; set; } = default!;
    public string BaseMaterial { get; set; } = default!;
    public string? Description { get; set; }
    public int ManufacturerId { get; set; }
    public Manufacturer? Manufacturer { get; set; }
    public int ShoeCategoryId { get; set; }
    public ShoeCategory? ShoeCategory { get; set; }
    public IList<ShoeVariant>? Variants { get; set; }
}
