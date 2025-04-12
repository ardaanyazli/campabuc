using campabuc.model.interfaces;

namespace campabuc.model;

public class ShoeBrand : IHasCreateDate, IHasDeleteDate
{
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
