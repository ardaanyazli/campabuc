using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class ContactInfoRepository(CamPabucContext context) : IContactInfoRepository
{
    public async Task AddContactInfoAsync(ContactInfo contactInfo,CancellationToken cancellationToken = default)
    {
        await context.ContactInfos.AddAsync(contactInfo,cancellationToken);
    }

    public async Task DeleteContactInfoAsync(Guid id,CancellationToken cancellationToken = default)
    {
        var contactInfo = await context.ContactInfos.FindAsync(id,cancellationToken) ?? throw new KeyNotFoundException($"ContactInfo with ID {id} not found.");

        context.ContactInfos.Remove(contactInfo);
    }

    public async Task<ContactInfo> GetContactInfoAsync(Guid id,CancellationToken cancellationToken = default)
    {
        return await context.ContactInfos
            .FindAsync(id,cancellationToken)
            ?? throw new KeyNotFoundException($"ContactInfo with ID {id} not found.");
    }

    public async Task<IList<ContactInfo>> GetContactInfoByContactIdAsync(Guid contactId,CancellationToken cancellationToken = default)
    {
        return await context.ContactInfos
            .Where(ci => ci.ContactId == contactId)
            .ToListAsync(cancellationToken) ?? throw new KeyNotFoundException($"No ContactInfo found for Contact ID {contactId}.");
    }

    public async Task<IList<ContactInfo>> GetContactInfosAsync(CancellationToken cancellationToken = default)
    {
        return await context.ContactInfos
             .ToListAsync(cancellationToken);
    }

    public void UpdateContactInfo(ContactInfo contactInfo)
    {
        context.ContactInfos.Update(contactInfo);
    }
}
