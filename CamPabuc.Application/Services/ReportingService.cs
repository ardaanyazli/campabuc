using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;

namespace CamPabuc.Application.Services;

public record ReportData(string Label, decimal Value, DateTime Date);

public interface IReportingService
{
    Task<decimal> GetProfitMarginAsync(int variantId, CancellationToken ct);
    Task<IList<ReportData>> GetInventoryAgingReportAsync(CancellationToken ct);
    Task<decimal> GetTotalSalesByDateRangeAsync(DateTime start, DateTime end, CancellationToken ct);
}

public class ReportingService : IReportingService
{
    private readonly IShoeVariantRepository _variantRepo;
    private readonly ISaleRepository _saleRepo;

    public ReportingService(IShoeVariantRepository variantRepo, ISaleRepository saleRepo)
    {
        _variantRepo = variantRepo;
        _saleRepo = saleRepo;
    }

    public async Task<decimal> GetProfitMarginAsync(int variantId, CancellationToken ct)
    {
        var variant = await _variantRepo.GetVariantAsync(variantId, ct);
        if (variant == null) return 0;
        return variant.RetailPrice - variant.CostPrice;
    }

    public async Task<IList<ReportData>> GetInventoryAgingReportAsync(CancellationToken ct)
    {
        var variants = await _variantRepo.GetVariantsAsync(ct);
        return variants.Select(v => new ReportData(
            v.SkuCode, 
            v.StockQuantity, 
            v.CreatedAt.ToDateTime(TimeOnly.MinValue)
        )).ToList();
    }

    public async Task<decimal> GetTotalSalesByDateRangeAsync(DateTime start, DateTime end, CancellationToken ct)
    {
        var sales = await _saleRepo.GetSalesAsync(ct);
        return sales
            .Where(s => s.TransactionDate >= start && s.TransactionDate <= end)
            .Sum(s => s.TotalAmount);
    }
}
