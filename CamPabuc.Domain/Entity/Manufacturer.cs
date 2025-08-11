
namespace CamPabuc.Domain.Entity;

public class Manufacturer : BaseEntity, IHasIntKey
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Address { get; set; } = default!;
    public IList<Shoe>? Shoes { get; set; }
}
