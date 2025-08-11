using CamPabuc.Domain.Entity;
namespace CamPabuc.Application.Interface;

public interface IShoeRepository
{
    Task<IList<Shoe>> GetAll(CancellationToken cancellationToken);
    Task<Shoe> GetById(Guid id, CancellationToken cancellationToken);
    Task CreateShoe(Shoe entity,CancellationToken cancellationToken);
    Task UpdateShoe(Shoe entity, CancellationToken cancellationToken);
    Task DeleteShoe(Guid id ,CancellationToken cancellationToken);

}
