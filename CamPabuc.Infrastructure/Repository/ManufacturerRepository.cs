using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace CamPabuc.Infrastructure.Repository;

public class ManufacturerRepository(CamPabucContext context) : IManufacturerRepository
{
    public async Task CreateManufacturerAsync(Manufacturer manufacturer, CancellationToken cancellationToken)
    {
        await context.Manufacturers.AddAsync(manufacturer, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteManufacturerAsync(int id, CancellationToken cancellationToken)
    {
        var manufacturer = await context.Manufacturers.FindAsync(id) ?? throw new KeyNotFoundException("Manufacturer Not Found");
        context.Manufacturers.Remove(manufacturer);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Manufacturer>> GetManufacturersAsync(CancellationToken cancellationToken)
    {
        return await context.Manufacturers.ToListAsync(cancellationToken);
    }

    public async Task<Manufacturer> GetManufacturerAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Manufacturers.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Manufacturer Not Found");
    }

    public void UpdateManufacturer(Manufacturer manufacturer, CancellationToken cancellationToken)
    {
        context.Manufacturers.Update(manufacturer);
        context.SaveChangesAsync(cancellationToken).Wait();
    }
}
