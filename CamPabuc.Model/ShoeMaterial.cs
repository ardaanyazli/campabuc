using campabuc.model.interfaces;

namespace campabuc.model;

public class ShoeMaterial : IHasCreateDate, IHasDeleteDate, IHasNumberId
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Value { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
