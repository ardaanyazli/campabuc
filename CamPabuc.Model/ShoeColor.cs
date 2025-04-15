using campabuc.model.interfaces;

namespace campabuc.model;

public class ShoeColor : IHasCreateDate, IHasDeleteDate, IHasNumberId
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
