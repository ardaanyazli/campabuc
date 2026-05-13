namespace CamPabuc.Domain.Entity;

public class ShoeVariant : BaseEntity, IHasIntKey
{
    public int Id { get; set; }
    public int ShoeModelId { get; set; }
    public ShoeModel? ShoeModel { get; set; }
    public string SkuCode { get; set; } = default!;
    public string Size { get; set; } = default!;
    public string Color { get; set; } = default!;
    public decimal CostPrice { get; set; }
    public decimal RetailPrice { get; set; }
    public int StockQuantity { get; set; }
}
