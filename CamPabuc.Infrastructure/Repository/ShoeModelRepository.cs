using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class ShoeModelRepository(CamPabucContext context) : IShoeModelRepository
{
    public async Task<IList<ShoeModel>> GetShoeModelsAsync(CancellationToken cancellationToken)
    {
        return await context.ShoeModels.ToListAsync(cancellationToken);
    }

    public async Task<ShoeModel> GetShoeModelAsync(int id, CancellationToken cancellationToken)
    {
        return await context.ShoeModels.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Shoe Model Not Found");
    }

    public async Task CreateShoeModelAsync(ShoeModel shoeModel, CancellationToken cancellationToken)
    {
        await context.ShoeModels.AddAsync(shoeModel, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public void UpdateShoeModel(ShoeModel shoeModel)
    {
        context.ShoeModels.Update(shoeModel);
    }

    public async Task DeleteShoeModelAsync(int id, CancellationToken cancellationToken)
    {
        var model = await context.ShoeModels.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Shoe Model Not Found");
        context.ShoeModels.Remove(model);
        await context.SaveChangesAsync(cancellationToken);
    }
}
