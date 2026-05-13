using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Repository;

public class SaleRepository : ISaleRepository
{
    private readonly CamPabucContext _context;

    public SaleRepository(CamPabucContext context)
    {
        _context = context;
    }

    public async Task<IList<Sale>> GetSalesAsync(CancellationToken cancellationToken)
    {
        return await _context.Sales.Include(s => s.Items).ToListAsync(cancellationToken);
    }

    public async Task<Sale> GetSaleAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Sales.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id, cancellationToken) 
            ?? throw new KeyNotFoundException("Sale Not Found");
    }

    public async Task CreateSaleAsync(Sale sale, CancellationToken cancellationToken)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void UpdateSale(Sale sale)
    {
        _context.Sales.Update(sale);
    }

    public async Task DeleteSaleAsync(int id, CancellationToken cancellationToken)
    {
        var sale = await _context.Sales.FindAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Sale Not Found");
        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
