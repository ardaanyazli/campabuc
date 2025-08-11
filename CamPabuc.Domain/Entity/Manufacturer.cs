
namespace CamPabuc.Domain.Entity;

public class Manufacturer
{
    public Guid Id { get; set; }
    public DateOnly CreatedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public string Name { get; set; }= default!;
    public string Phone { get; set; }= default!;
    public string Address { get; set; }= default!;
    public IList<Shoe>? Shoes { get; set; }
}
