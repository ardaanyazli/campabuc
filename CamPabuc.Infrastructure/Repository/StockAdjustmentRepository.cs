using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class StockAdjustmentRepository : IStockAdjustmentRepository
{
    private readonly CamPabucContext _context;

    public StockAdjustmentRepository(CamPabucContext context)
    {
        _context = context;
    }

    public async Task<IList<StockAdjustment>> GetAdjustmentsAsync(CancellationToken cancellationToken)
    {
        return await _context.StockAdjustments.ToListAsync(cancellationToken);
    }

    public async Task<StockAdjustment> GetAdjustmentAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.StockAdjustments.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Stock Adjustment Not Found");
    }

    public async Task CreateAdjustmentAsync(StockAdjustment adjustment, CancellationToken cancellationToken)
    {
        await _context.StockAdjustments.AddAsync(adjustment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void UpdateAdjustment(StockAdjustment adjustment)
    {
        _context.StockAdjustments.Update(adjustment);
    }

    public async Task DeleteAdjustmentAsync(int id, CancellationToken cancellationToken)
    {
        var adjustment = await _context.StockAdjustments.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Stock Adjustment Not Found");
        _context.StockAdjustments.Remove(adjustment);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
