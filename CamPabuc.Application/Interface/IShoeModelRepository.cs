using CamPabuc.Domain.Entity;
namespace CamPabuc.Application.Interface;

public interface IShoeModelRepository
{
    Task<IList<ShoeModel>> GetShoeModelsAsync(CancellationToken cancellationToken);
    Task<ShoeModel> GetShoeModelAsync(int id, CancellationToken cancellationToken);
    Task CreateShoeModelAsync(ShoeModel shoeModel, CancellationToken cancellationToken);
    void UpdateShoeModel(ShoeModel shoeModel);
    Task DeleteShoeModelAsync(int id, CancellationToken cancellationToken);
}
