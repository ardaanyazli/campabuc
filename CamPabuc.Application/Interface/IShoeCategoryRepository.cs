using CamPabuc.Domain.Entity;

namespace CamPabuc.Application.Interface;

public interface IShoeCategoryRepository
{
    Task<IList<ShoeCategory>> GetShoeCategoriesAsync(CancellationToken cancellationToken = default);
    Task<ShoeCategory> GetShoeCategoryAsync(int id, CancellationToken cancellationToken = default);
    Task AddShoeCategoryAsync(ShoeCategory shoeCategory, CancellationToken cancellationToken = default);
    void UpdateShoeCategory(ShoeCategory shoeCategory);
    Task DeleteShoeCategoryAsync(int id, CancellationToken cancellationToken = default);

}
