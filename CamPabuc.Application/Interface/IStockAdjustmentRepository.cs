using CamPabuc.Domain.Entity;
namespace CamPabuc.Application.Interface;

public interface IStockAdjustmentRepository
{
    Task<IList<StockAdjustment>> GetAdjustmentsAsync(CancellationToken cancellationToken);
    Task<StockAdjustment> GetAdjustmentAsync(int id, CancellationToken cancellationToken);
    Task CreateAdjustmentAsync(StockAdjustment adjustment, CancellationToken cancellationToken);
    void UpdateAdjustment(StockAdjustment adjustment);
    Task DeleteAdjustmentAsync(int id, CancellationToken cancellationToken);
}
