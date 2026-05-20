using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class ShoeVariantRepository(CamPabucContext context) : IShoeVariantRepository
{
    public async Task<IList<ShoeVariant>> GetVariantsAsync(CancellationToken cancellationToken)
    {
        return await context.ShoeVariants.ToListAsync(cancellationToken);
    }

    public async Task<ShoeVariant> GetVariantAsync(int id, CancellationToken cancellationToken)
    {
        return await context.ShoeVariants.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Shoe Variant Not Found");
    }

    public async Task<IList<ShoeVariant>> GetVariantsByModelIdAsync(int modelId, CancellationToken cancellationToken)
    {
        return await context.ShoeVariants
            .Where(v => v.ShoeModelId == modelId)
            .ToListAsync(cancellationToken);
    }

    public async Task CreateVariantAsync(ShoeVariant variant, CancellationToken cancellationToken)
    {
        await context.ShoeVariants.AddAsync(variant, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public void UpdateVariant(ShoeVariant variant)
    {
        context.ShoeVariants.Update(variant);
    }

    public async Task DeleteVariantAsync(int id, CancellationToken cancellationToken)
    {
        var variant = await context.ShoeVariants.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Shoe Variant Not Found");
        context.ShoeVariants.Remove(variant);
        await context.SaveChangesAsync(cancellationToken);
    }
}
