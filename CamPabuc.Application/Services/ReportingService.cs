using CamPabuc.Application.Dto;
using CamPabuc.Application.Interface;

namespace CamPabuc.Application.Services;

public class ReportingService(IShoeVariantRepository variantRepo, ISaleRepository saleRepo) : IReportingService
{
    public async Task<decimal> GetProfitMarginAsync(int variantId, CancellationToken ct)
    {
        var variant = await variantRepo.GetVariantAsync(variantId, ct);
        if (variant == null) return 0;
        return variant.RetailPrice - variant.CostPrice;
    }

    public async Task<IList<ReportData>> GetInventoryAgingReportAsync(CancellationToken ct)
    {
        var variants = await variantRepo.GetVariantsAsync(ct);
        return [.. variants.Select(v => new ReportData(
            v.SkuCode,
            v.StockQuantity,
            v.CreatedAt.ToDateTime(TimeOnly.MinValue)
        ))];
    }

    public async Task<decimal> GetTotalSalesByDateRangeAsync(DateTime start, DateTime end, CancellationToken ct)
    {
        var sales = await saleRepo.GetSalesAsync(ct);
        return sales
            .Where(s => s.TransactionDate >= start && s.TransactionDate <= end)
            .Sum(s => s.TotalAmount);
    }
}
