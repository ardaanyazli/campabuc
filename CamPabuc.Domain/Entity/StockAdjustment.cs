namespace CamPabuc.Domain.Entity;
using CamPabuc.Domain.Enums;

public class StockAdjustment : BaseEntity, IHasIntKey
{
    public int Id { get; set; }
    public int ShoeVariantId { get; set; }
    public ShoeVariant? ShoeVariant { get; set; }
    public StockAdjustmentType Type { get; set; }
    public int Quantity { get; set; }
    public DateOnly Date { get; set; }
    public string Reason { get; set; } = default!;
}
