using CamPabuc.Application.Dto;

namespace CamPabuc.Application.Interface;

public interface IReportingService
{
    Task<decimal> GetProfitMarginAsync(int variantId, CancellationToken ct);
    Task<IList<ReportData>> GetInventoryAgingReportAsync(CancellationToken ct);
    Task<decimal> GetTotalSalesByDateRangeAsync(DateTime start, DateTime end, CancellationToken ct);
}

