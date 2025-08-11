using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class ContactInfoRepository : IContactInfoRepository
{
    private readonly CamPabucContext _context;

    public ContactInfoRepository(CamPabucContext context)
    {
        _context = context;
    }

    public async Task AddContactInfoAsync(ContactInfo contactInfo,CancellationToken cancellationToken = default)
    {
        await _context.ContactInfos.AddAsync(contactInfo,cancellationToken);
    }

    public async Task DeleteContactInfoAsync(Guid id,CancellationToken cancellationToken = default)
    {
        var contactInfo = await _context.ContactInfos.FindAsync(id,cancellationToken) ?? throw new KeyNotFoundException($"ContactInfo with ID {id} not found.");

        _context.ContactInfos.Remove(contactInfo);
    }

    public async Task<ContactInfo> GetContactInfoAsync(Guid id,CancellationToken cancellationToken = default)
    {
        return await _context.ContactInfos
            .FindAsync(id,cancellationToken)
            ?? throw new KeyNotFoundException($"ContactInfo with ID {id} not found.");
    }

    public async Task<IList<ContactInfo>> GetContactInfoByContactIdAsync(Guid contactId,CancellationToken cancellationToken = default)
    {
        return await _context.ContactInfos
            .Where(ci => ci.ContactId == contactId)
            .ToListAsync(cancellationToken) ?? throw new KeyNotFoundException($"No ContactInfo found for Contact ID {contactId}.");
    }

    public async Task<IList<ContactInfo>> GetContactInfosAsync(CancellationToken cancellationToken = default)
    {
        return await _context.ContactInfos
             .ToListAsync(cancellationToken);
    }

    public void UpdateContactInfo(ContactInfo contactInfo)
    {
        _context.ContactInfos.Update(contactInfo);
    }
}