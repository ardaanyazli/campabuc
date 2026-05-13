using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class ShoeVariantRepository : IShoeVariantRepository
{
    private readonly CamPabucContext _context;

    public ShoeVariantRepository(CamPabucContext context)
    {
        _context = context;
    }

    public async Task<IList<ShoeVariant>> GetVariantsAsync(CancellationToken cancellationToken)
    {
        return await _context.ShoeVariants.ToListAsync(cancellationToken);
    }

    public async Task<ShoeVariant> GetVariantAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.ShoeVariants.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Shoe Variant Not Found");
    }

    public async Task<IList<ShoeVariant>> GetVariantsByModelIdAsync(int modelId, CancellationToken cancellationToken)
    {
        return await _context.ShoeVariants
            .Where(v => v.ShoeModelId == modelId)
            .ToListAsync(cancellationToken);
    }

    public async Task CreateVariantAsync(ShoeVariant variant, CancellationToken cancellationToken)
    {
        await _context.ShoeVariants.AddAsync(variant, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void UpdateVariant(ShoeVariant variant)
    {
        _context.ShoeVariants.Update(variant);
    }

    public async Task DeleteVariantAsync(int id, CancellationToken cancellationToken)
    {
        var variant = await _context.ShoeVariants.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Shoe Variant Not Found");
        _context.ShoeVariants.Remove(variant);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
