using CamPabuc.Domain.Entity;
namespace CamPabuc.Application.Interface;

public interface ISaleRepository
{
    Task<IList<Sale>> GetSalesAsync(CancellationToken cancellationToken);
    Task<Sale> GetSaleAsync(int id, CancellationToken cancellationToken);
    Task CreateSaleAsync(Sale sale, CancellationToken cancellationToken);
    void UpdateSale(Sale sale);
    Task DeleteSaleAsync(int id, CancellationToken cancellationToken);
}
