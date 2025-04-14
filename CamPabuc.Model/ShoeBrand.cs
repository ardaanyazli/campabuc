using campabuc.model.interfaces;

namespace campabuc.model;

public class ShoeBrand : IHasCreateDate, IHasDeleteDate, IHasIntId
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
