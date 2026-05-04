
using CamPabuc.Application.Interface;
using CamPabuc.Infrastructure.Persistence;

namespace CamPabuc.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{

    private readonly CamPabucContext _context;

    public UnitOfWork(CamPabucContext context)
    {
        _context = context;
        ContactRepository = new ContactRepository(_context);
        ContactInfoRepository = new ContactInfoRepository(_context);
        ShoeRepository = new ShoeRepository(_context);
        ShoeCategoryRepository = new ShoeCategoryRepository(_context);
        ManufacturerRepository = new ManufacturerRepository(_context);
    }

    public IShoeRepository ShoeRepository { get; }
    public IShoeCategoryRepository ShoeCategoryRepository { get; }
    public IManufacturerRepository ManufacturerRepository { get; }
    public IContactRepository ContactRepository { get; }
    public IContactInfoRepository ContactInfoRepository { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        _context.ChangeTracker.DetectChanges();
        return _context.SaveChangesAsync(cancellationToken);
    }
}
