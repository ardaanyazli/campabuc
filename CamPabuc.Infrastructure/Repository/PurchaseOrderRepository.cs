using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class PurchaseOrderRepository(CamPabucContext context) : IPurchaseOrderRepository
{
    public async Task<IList<PurchaseOrder>> GetPurchaseOrdersAsync(CancellationToken cancellationToken)
    {
        return await context.PurchaseOrders.Include(po => po.Items).ToListAsync(cancellationToken);
    }

    public async Task<PurchaseOrder> GetPurchaseOrderAsync(int id, CancellationToken cancellationToken)
    {
        return await context.PurchaseOrders.Include(po => po.Items).FirstOrDefaultAsync(po => po.Id == id, cancellationToken) 
            ?? throw new KeyNotFoundException("Purchase Order Not Found");
    }

    public async Task CreatePurchaseOrderAsync(PurchaseOrder po, CancellationToken cancellationToken)
    {
        await context.PurchaseOrders.AddAsync(po, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public void UpdatePurchaseOrder(PurchaseOrder po)
    {
        context.PurchaseOrders.Update(po);
    }

    public async Task DeletePurchaseOrderAsync(int id, CancellationToken cancellationToken)
    {
        var po = await context.PurchaseOrders.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Purchase Order Not Found");
        context.PurchaseOrders.Remove(po);
        await context.SaveChangesAsync(cancellationToken);
    }
}
