using CamPabuc.Domain.Entity;
namespace CamPabuc.Application.Interface;

public interface IShoeRepository
{
    Task<IList<Shoe>> GetShoesAsync(CancellationToken cancellationToken);
    Task<Shoe> GetShoeAsync(int id, CancellationToken cancellationToken);
    Task CreateShoeAsync(Shoe shoe, CancellationToken cancellationToken);
    void UpdateShoe(Shoe shoe);
    Task DeleteShoeAsync(id id, CancellationToken cancellationToken);

}
