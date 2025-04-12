using campabuc.model.interfaces;

namespace campabuc.model;
public class Manufacturer : IHasCreateDate, IHasDeleteDate
{
    public required string Name { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
