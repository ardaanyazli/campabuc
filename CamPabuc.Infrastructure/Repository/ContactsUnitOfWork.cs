
using CamPabuc.Application.Interface;
using CamPabuc.Infrastructure.Persistence;

namespace CamPabuc.Infrastructure.Repository;

public class ContactsUnitOfWork : IContactsUnitOfWork
{

    private readonly CamPabucContext _context;

    public ContactsUnitOfWork(CamPabucContext context)
    {
        _context = context;
        ContactRepository = new ContactRepository(_context);
        ContactInfoRepository = new ContactInfoRepository(_context);
    }
    
    public IContactRepository ContactRepository { get; }

    public IContactInfoRepository ContactInfoRepository { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        _context.ChangeTracker.DetectChanges();
        return _context.SaveChangesAsync(cancellationToken);
    }
}
