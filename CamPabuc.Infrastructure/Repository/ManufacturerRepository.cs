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
    public async Task CreateManufacturer(Manufacturer manufacturer, CancellationToken cancellationToken)
    {

        await _context.Manufacturers.AddAsync(manufacturer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteManufacturer(int id, CancellationToken cancellationToken)
    {
        var manufacturer = await _context.Manufacturers.FindAsync(id) ?? throw new KeyNotFoundException("Manufacturer Not Found");
        _context.Manufacturers.Remove(manufacturer);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Manufacturer>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Manufacturers.ToListAsync(cancellationToken);
    }

    public async Task<Manufacturer> GetById(int id, CancellationToken cancellationToken)
    {
        return await _context.Manufacturers.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Manufacturer Not Found");
    }

    public async Task UpdateManufacturer(Manufacturer manufacturer, CancellationToken cancellationToken)
    {
        _context.Manufacturers.Update(manufacturer);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
