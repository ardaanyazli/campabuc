namespace CamPabuc.Domain.Entity;

public class POItem : BaseEntity, IHasIntKey
{
    public int Id { get; set; }
    public int PurchaseOrderId { get; set; }
    public PurchaseOrder? PurchaseOrder { get; set; }
    public int ShoeVariantId { get; set; }
    public ShoeVariant? ShoeVariant { get; set; }
    public int QuantityOrdered { get; set; }
    public int QuantityReceived { get; set; }
}
