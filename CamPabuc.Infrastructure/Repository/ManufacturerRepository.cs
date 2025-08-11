using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace CamPabuc.Infrastructure.Repository;

public class ManufacturerRepository : IManufacturerRepository
{
    private readonly CamPabucContext _context;

    public ManufacturerRepository(CamPabucContext context)
    {
        _context = context;
    }
    public async Task CreateManufacturer(Manufacturer entity,CancellationToken cancellationToken)
    {
    
        await _context.Manufacturers.AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteManufacturer(Guid id, CancellationToken cancellationToken)
    {
        var entity= await _context.Manufacturers.FindAsync(id) ?? throw new KeyNotFoundException("Manufacturer Not Found");
        _context.Manufacturers.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Manufacturer>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Manufacturers.ToListAsync(cancellationToken); 
    }

    public async Task<Manufacturer> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Manufacturers.FindAsync(id,cancellationToken) ?? throw new KeyNotFoundException("Manufacturer Not Found");
    }

    public async Task UpdateManufacturer(Manufacturer entity, CancellationToken cancellationToken)
    {
        _context.Manufacturers.Update(entity);
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}
