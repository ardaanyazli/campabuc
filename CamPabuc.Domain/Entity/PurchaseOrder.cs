namespace CamPabuc.Domain.Entity;
using CamPabuc.Domain.Enums;

public class PurchaseOrder : BaseEntity, IHasIntKey
{
    public int Id { get; set; }
    public int ManufacturerId { get; set; }
    public Manufacturer? Manufacturer { get; set; }
    public DateOnly OrderDate { get; set; }
    public DateOnly ExpectedDate { get; set; }
    public PurchaseOrderStatus Status { get; set; }
    public IList<POItem>? Items { get; set; }
}
