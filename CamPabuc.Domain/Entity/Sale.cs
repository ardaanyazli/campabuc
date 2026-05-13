namespace CamPabuc.Domain.Entity;

public class Sale : BaseEntity, IHasIntKey
{
    public int Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal DiscountApplied { get; set; }
    public string PaymentMethod { get; set; } = default!;
    public IList<SaleItem>? Items { get; set; }
}
