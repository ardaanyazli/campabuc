using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class StockAdjustmentRepository(CamPabucContext context) : IStockAdjustmentRepository
{
    public async Task<IList<StockAdjustment>> GetAdjustmentsAsync(CancellationToken cancellationToken)
    {
        return await context.StockAdjustments.ToListAsync(cancellationToken);
    }

    public async Task<StockAdjustment> GetAdjustmentAsync(int id, CancellationToken cancellationToken)
    {
        return await context.StockAdjustments.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Stock Adjustment Not Found");
    }

    public async Task CreateAdjustmentAsync(StockAdjustment adjustment, CancellationToken cancellationToken)
    {
        await context.StockAdjustments.AddAsync(adjustment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public void UpdateAdjustment(StockAdjustment adjustment)
    {
        context.StockAdjustments.Update(adjustment);
    }

    public async Task DeleteAdjustmentAsync(int id, CancellationToken cancellationToken)
    {
        var adjustment = await context.StockAdjustments.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Stock Adjustment Not Found");
        context.StockAdjustments.Remove(adjustment);
        await context.SaveChangesAsync(cancellationToken);
    }
}
