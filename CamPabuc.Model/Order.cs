using campabuc.model.interfaces;

namespace campabuc.model;

public class Order : IHasCreateDate, IHasDeleteDate, IHasEpochId
{
    public string Id { get; set; }
    public IList<OrderItem>? Items { get; set; }
    public decimal Total { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
