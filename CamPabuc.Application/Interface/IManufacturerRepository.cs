using CamPabuc.Domain.Entity;

namespace CamPabuc.Application.Interface;

public interface IManufacturerRepository
{
    Task<IList<Manufacturer>> GetManufacturersAsync(CancellationToken cancellationToken);
    Task<Manufacturer> GetManufacturerAsync(int id, CancellationToken cancellationToken);
    Task CreateManufacturerAsync(Manufacturer manufacturer, CancellationToken cancellationToken);
    void UpdateManufacturer(Manufacturer manufacturer, CancellationToken cancellationToken);
    Task DeleteManufacturerAsync(int id, CancellationToken cancellationToken);
}
