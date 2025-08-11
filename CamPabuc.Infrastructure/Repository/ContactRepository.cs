
using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class ContactRepository : IContactRepository
{
    private readonly CamPabucContext _context;

    public ContactRepository(CamPabucContext context)
    {
        _context = context;
    }


    public async Task CreateContactAsync(Contact contact,CancellationToken cancellationToken = default)
    {
        await _context.Contacts.AddAsync(contact, cancellationToken);
    }

    public async Task DeleteContactAsync(Guid id,CancellationToken cancellationToken = default)
    {
        var contact = await _context.Contacts.FindAsync(id,cancellationToken) ?? throw new NullReferenceException($"Contact with {id} not found.");

        _context.Contacts.Remove(contact);
    }

    public async Task<Contact> GetContactByIdAsync(Guid id,CancellationToken cancellationToken = default)
    {
        var contact = await _context.Contacts.FindAsync(id,cancellationToken) ?? throw new NullReferenceException($"Contact with {id} not found.");

        return contact;
    }

    public async Task<IList<Contact>> GetContactsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Contacts.ToListAsync(cancellationToken);
    }

    public void UpdateContact(Contact contact)
    {
        _context.Contacts.Update(contact);
    }
}
