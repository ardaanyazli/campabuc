namespace CamPabuc.Domain.Entity;

public class SaleItem : BaseEntity, IHasIntKey
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    public Sale? Sale { get; set; }
    public int ShoeVariantId { get; set; }
    public ShoeVariant? ShoeVariant { get; set; }
    public int Quantity { get; set; }
    public decimal PriceAtSale { get; set; }
}
