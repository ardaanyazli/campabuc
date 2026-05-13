using CamPabuc.Domain.Entity;
namespace CamPabuc.Application.Interface;

public interface IShoeVariantRepository
{
    Task<IList<ShoeVariant>> GetVariantsAsync(CancellationToken cancellationToken);
    Task<ShoeVariant> GetVariantAsync(int id, CancellationToken cancellationToken);
    Task<IList<ShoeVariant>> GetVariantsByModelIdAsync(int modelId, CancellationToken cancellationToken);
    Task CreateVariantAsync(ShoeVariant variant, CancellationToken cancellationToken);
    void UpdateVariant(ShoeVariant variant);
    Task DeleteVariantAsync(int id, CancellationToken cancellationToken);
}
