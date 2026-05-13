using CamPabuc.Application.Interface;
using CamPabuc.Infrastructure.Persistence;

namespace CamPabuc.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly CamPabucContext _context;

    public UnitOfWork(CamPabucContext context)
    {
        _context = context;
        ManufacturerRepository = new ManufacturerRepository(_context);
        ShoeCategoryRepository = new ShoeCategoryRepository(_context);
        ShoeModelRepository = new ShoeModelRepository(_context);
        ShoeVariantRepository = new ShoeVariantRepository(_context);
        PurchaseOrderRepository = new PurchaseOrderRepository(_context);
        SaleRepository = new SaleRepository(_context);
        StockAdjustmentRepository = new StockAdjustmentRepository(_context);
        ContactRepository = new ContactRepository(_context);
        ContactInfoRepository = new ContactInfoRepository(_context);
    }

    public IManufacturerRepository ManufacturerRepository { get; }
    public IShoeCategoryRepository ShoeCategoryRepository { get; }
    public IShoeModelRepository ShoeModelRepository { get; }
    public IShoeVariantRepository ShoeVariantRepository { get; }
    public IPurchaseOrderRepository PurchaseOrderRepository { get; }
    public ISaleRepository SaleRepository { get; }
    public IStockAdjustmentRepository StockAdjustmentRepository { get; }
    public IContactRepository ContactRepository { get; }
    public IContactInfoRepository ContactInfoRepository { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        _context.ChangeTracker.DetectChanges();
        return _context.SaveChangesAsync(cancellationToken);
    }
}
