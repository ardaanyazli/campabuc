namespace CamPabuc.Application.Interface;

public interface IUnitOfWork
{
    IManufacturerRepository ManufacturerRepository { get; }
    IShoeCategoryRepository ShoeCategoryRepository { get; }
    IShoeModelRepository ShoeModelRepository { get; }
    IShoeVariantRepository ShoeVariantRepository { get; }
    IPurchaseOrderRepository PurchaseOrderRepository { get; }
    ISaleRepository SaleRepository { get; }
    IStockAdjustmentRepository StockAdjustmentRepository { get; }
    IContactRepository ContactRepository { get; }
    IContactInfoRepository ContactInfoRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
