using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class ShoeRepository : IShoeRepository
{
    private readonly CamPabucContext _context;

    public ShoeRepository(CamPabucContext context)
    {
        _context = context;
    }
    public async Task CreateShoe(Shoe entity,CancellationToken cancellationToken)
    {
        await _context.Shoes.AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteShoe(Guid id, CancellationToken cancellationToken)
    {
        var entity= await _context.Shoes.FindAsync(id) ?? throw new KeyNotFoundException("Shoe Not Found");
        _context.Shoes.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async  Task<IList<Shoe>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Shoes.ToListAsync(cancellationToken); 
    }

    public async Task<Shoe> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Shoes.FindAsync(id,cancellationToken) ?? throw new KeyNotFoundException("Shoe Not Found");
    }

    public async Task UpdateShoe(Shoe entity, CancellationToken cancellationToken)
    {
        _context.Shoes.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
