using CamPabuc.Domain.Entity;

namespace CamPabuc.Application.Interface;

public interface IManufacturerRepository
{
    Task<IList<Manufacturer>> GetAll(CancellationToken cancellationToken);
    Task<Manufacturer> GetById(Guid id, CancellationToken cancellationToken);
    Task CreateManufacturer(Manufacturer entity, CancellationToken cancellationToken);
    Task UpdateManufacturer(Manufacturer entity, CancellationToken cancellationToken);
    Task DeleteManufacturer(Guid id, CancellationToken cancellationToken);
}
