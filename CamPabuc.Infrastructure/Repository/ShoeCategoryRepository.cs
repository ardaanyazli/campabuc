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

	public Task AddShoeCategoryAsync(ShoeCategory shoeCategory, CancellationToken cancellationToken = default)
	{
		await _context.ShoeCategories.AddAsync(shoeCategory,cancellationToken);
	}

	public Task DeleteShoeCategoryAsync(int id, CancellationToken cancellationToken = default)
	{
	}

	public Task<IList<ShoeCategory>> GetShoeCategoriesAsync(CancellationToken cancellationToken = default)
	{
	}

	public Task<ShoeCategory> GetShoeCategoryAsync(int id, CancellationToken cancellationToken = default)
	{
	}

	public void UpdateShoeCategory(ShoeCategory shoeCategory)
	{
	}
}
