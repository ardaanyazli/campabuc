using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class ShoeModelRepository : IShoeModelRepository
{
    private readonly CamPabucContext _context;

    public ShoeModelRepository(CamPabucContext context)
    {
        _context = context;
    }

    public async Task<IList<ShoeModel>> GetShoeModelsAsync(CancellationToken cancellationToken)
    {
        return await _context.ShoeModels.ToListAsync(cancellationToken);
    }

    public async Task<ShoeModel> GetShoeModelAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.ShoeModels.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Shoe Model Not Found");
    }

    public async Task CreateShoeModelAsync(ShoeModel shoeModel, CancellationToken cancellationToken)
    {
        await _context.ShoeModels.AddAsync(shoeModel, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void UpdateShoeModel(ShoeModel shoeModel)
    {
        _context.ShoeModels.Update(shoeModel);
    }

    public async Task DeleteShoeModelAsync(int id, CancellationToken cancellationToken)
    {
        var model = await _context.ShoeModels.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Shoe Model Not Found");
        _context.ShoeModels.Remove(model);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
