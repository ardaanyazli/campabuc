using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class ShoeCategoryRepository(CamPabucContext context) : IShoeCategoryRepository
{
    public async Task AddShoeCategoryAsync(ShoeCategory shoeCategory, CancellationToken cancellationToken = default)
    {
        await context.ShoeCategories.AddAsync(shoeCategory, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteShoeCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        var category = await context.ShoeCategories.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Shoe Category Not Found");
        context.ShoeCategories.Remove(category);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<ShoeCategory>> GetShoeCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await context.ShoeCategories.ToListAsync(cancellationToken);
    }

    public async Task<ShoeCategory> GetShoeCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.ShoeCategories.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Shoe Category Not Found");
    }

    public void UpdateShoeCategory(ShoeCategory shoeCategory)
    {
        context.ShoeCategories.Update(shoeCategory);
    }
}
