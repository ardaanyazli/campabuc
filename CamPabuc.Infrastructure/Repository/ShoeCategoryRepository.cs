using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class ShoeCategoryRepository : IShoeCategoryRepository
{
    private readonly CamPabucContext _context;

    public ShoeCategoryRepository(CamPabucContext context)
    {
        _context = context;
    }

    public async Task AddShoeCategoryAsync(ShoeCategory shoeCategory, CancellationToken cancellationToken = default)
    {
        await _context.ShoeCategories.AddAsync(shoeCategory, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteShoeCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        var category = await _context.ShoeCategories.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Shoe Category Not Found");
        _context.ShoeCategories.Remove(category);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<ShoeCategory>> GetShoeCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.ShoeCategories.ToListAsync(cancellationToken);
    }

    public async Task<ShoeCategory> GetShoeCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.ShoeCategories.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Shoe Category Not Found");
    }

    public void UpdateShoeCategory(ShoeCategory shoeCategory)
    {
        _context.ShoeCategories.Update(shoeCategory);
    }
}
