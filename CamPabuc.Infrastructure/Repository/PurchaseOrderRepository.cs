using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class PurchaseOrderRepository : IPurchaseOrderRepository
{
    private readonly CamPabucContext _context;

    public PurchaseOrderRepository(CamPabucContext context)
    {
        _context = context;
    }

    public async Task<IList<PurchaseOrder>> GetPurchaseOrdersAsync(CancellationToken cancellationToken)
    {
        return await _context.PurchaseOrders.Include(po => po.Items).ToListAsync(cancellationToken);
    }

    public async Task<PurchaseOrder> GetPurchaseOrderAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.PurchaseOrders.Include(po => po.Items).FirstOrDefaultAsync(po => po.Id == id, cancellationToken) 
            ?? throw new KeyNotFoundException("Purchase Order Not Found");
    }

    public async Task CreatePurchaseOrderAsync(PurchaseOrder po, CancellationToken cancellationToken)
    {
        await _context.PurchaseOrders.AddAsync(po, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void UpdatePurchaseOrder(PurchaseOrder po)
    {
        _context.PurchaseOrders.Update(po);
    }

    public async Task DeletePurchaseOrderAsync(int id, CancellationToken cancellationToken)
    {
        var po = await _context.PurchaseOrders.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Purchase Order Not Found");
        _context.PurchaseOrders.Remove(po);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
