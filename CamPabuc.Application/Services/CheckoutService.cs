using CamPabuc.Domain.Entity;
using CamPabuc.Application.Interface;

namespace CamPabuc.Application.Services;

public interface ICheckoutService
{
    decimal CalculateSubtotal(IList<SaleItem> items);
    decimal ApplyDiscount(decimal subtotal, decimal discountPercent, decimal fixedAmount);
    decimal CalculateTotal(decimal subtotal, decimal taxRate, decimal discountAmount);
    Task FinalizeSale(Sale sale, CancellationToken ct);
}

public class CheckoutService : ICheckoutService
{
    private readonly ISaleRepository _saleRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CheckoutService(ISaleRepository saleRepo, IUnitOfWork unitOfWork)
    {
        _saleRepo = saleRepo;
        _unitOfWork = unitOfWork;
    }

    public decimal CalculateSubtotal(IList<SaleItem> items)
    {
        return items.Sum(i => i.PriceAtSale * i.Quantity);
    }

    public decimal ApplyDiscount(decimal subtotal, decimal discountPercent, decimal fixedAmount)
    {
        var discounted = subtotal * (1 - (discountPercent / 100));
        return discounted - fixedAmount;
    }

    public decimal CalculateTotal(decimal subtotal, decimal taxRate, decimal discountAmount)
    {
        var taxableAmount = subtotal - discountAmount;
        return taxableAmount * (1 + taxRate);
    }

    public async Task FinalizeSale(Sale sale, CancellationToken ct)
    {
        await _saleRepo.CreateSaleAsync(sale, ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
