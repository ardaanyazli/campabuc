using CamPabuc.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController(IReportingService reportingService) : ControllerBase
{
    [HttpGet("profit-margin/{variantId}")]
    public async Task<IActionResult> GetProfitMargin(int variantId, CancellationToken ct) 
        => Ok(await reportingService.GetProfitMarginAsync(variantId, ct));

    [HttpGet("inventory-aging")]
    public async Task<IActionResult> GetAgingReport(CancellationToken ct) 
        => Ok(await reportingService.GetInventoryAgingReportAsync(ct));

    [HttpGet("sales-summary")]
    public async Task<IActionResult> GetSalesSummary([FromQuery] DateTime start, [FromQuery] DateTime end, CancellationToken ct) 
        => Ok(await reportingService.GetTotalSalesByDateRangeAsync(start, end, ct));
}
