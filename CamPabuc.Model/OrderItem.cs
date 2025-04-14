using campabuc.model.interfaces;

namespace campabuc.model;

public class OrderItem : IHasCreateDate, IHasDeleteDate, IHasEpochId
{
    public string Id { get; set; }
    public string? ShoeId { get; set; }
    public decimal? Discount { get; set; }
    public ushort Quantity { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
