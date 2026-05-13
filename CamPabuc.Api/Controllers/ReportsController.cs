using Microsoft.AspNetCore.Mvc;
using CamPabuc.Application.Services;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IReportingService _reportingService;
    public ReportsController(IReportingService reportingService) => _reportingService = reportingService;

    [HttpGet("profit-margin/{variantId}")]
    public async Task<IActionResult> GetProfitMargin(int variantId, CancellationToken ct) 
        => Ok(await _reportingService.GetProfitMarginAsync(variantId, ct));

    [HttpGet("inventory-aging")]
    public async Task<IActionResult> GetAgingReport(CancellationToken ct) 
        => Ok(await _reportingService.GetInventoryAgingReportAsync(ct));

    [HttpGet("sales-summary")]
    public async Task<IActionResult> GetSalesSummary([FromQuery] DateTime start, [FromQuery] DateTime end, CancellationToken ct) 
        => Ok(await _reportingService.GetTotalSalesByDateRangeAsync(start, end, ct));
}
