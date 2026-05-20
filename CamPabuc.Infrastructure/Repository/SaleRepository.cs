using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class SaleRepository(CamPabucContext context) : ISaleRepository
{
    public async Task<IList<Sale>> GetSalesAsync(CancellationToken cancellationToken)
    {
        return await context.Sales.Include(s => s.Items).ToListAsync(cancellationToken);
    }

    public async Task<Sale> GetSaleAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Sales.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id, cancellationToken) 
            ?? throw new KeyNotFoundException("Sale Not Found");
    }

    public async Task CreateSaleAsync(Sale sale, CancellationToken cancellationToken)
    {
        await context.Sales.AddAsync(sale, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public void UpdateSale(Sale sale)
    {
        context.Sales.Update(sale);
    }

    public async Task DeleteSaleAsync(int id, CancellationToken cancellationToken)
    {
        var sale = await context.Sales.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Sale Not Found");
        context.Sales.Remove(sale);
        await context.SaveChangesAsync(cancellationToken);
    }
}
