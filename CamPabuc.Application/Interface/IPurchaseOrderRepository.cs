using CamPabuc.Domain.Entity;
namespace CamPabuc.Application.Interface;

public interface IPurchaseOrderRepository
{
    Task<IList<PurchaseOrder>> GetPurchaseOrdersAsync(CancellationToken cancellationToken);
    Task<PurchaseOrder> GetPurchaseOrderAsync(int id, CancellationToken cancellationToken);
    Task CreatePurchaseOrderAsync(PurchaseOrder po, CancellationToken cancellationToken);
    void UpdatePurchaseOrder(PurchaseOrder po);
    Task DeletePurchaseOrderAsync(int id, CancellationToken cancellationToken);
}
