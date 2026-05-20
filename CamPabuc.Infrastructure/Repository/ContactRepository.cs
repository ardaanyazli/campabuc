
using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class ContactRepository(CamPabucContext context) : IContactRepository
{
    public async Task CreateContactAsync(Contact contact,CancellationToken cancellationToken = default)
    {
        await context.Contacts.AddAsync(contact, cancellationToken);
    }

    public async Task DeleteContactAsync(Guid id,CancellationToken cancellationToken = default)
    {
        var contact = await context.Contacts.FindAsync(id,cancellationToken) ?? throw new NullReferenceException($"Contact with {id} not found.");

        context.Contacts.Remove(contact);
    }

    public async Task<Contact> GetContactByIdAsync(Guid id,CancellationToken cancellationToken = default)
    {
        var contact = await context.Contacts.FindAsync(id,cancellationToken) ?? throw new NullReferenceException($"Contact with {id} not found.");

        return contact;
    }

    public async Task<IList<Contact>> GetContactsAsync(CancellationToken cancellationToken = default)
    {
        return await context.Contacts.ToListAsync(cancellationToken);
    }

    public void UpdateContact(Contact contact)
    {
        context.Contacts.Update(contact);
    }
}
