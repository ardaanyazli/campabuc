using Microsoft.AspNetCore.Mvc;
using CamPabuc.Application.Interface;
using CamPabuc.Application.Services;
using CamPabuc.Domain.Entity;
using CamPabuc.Domain.Enums;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;
    public InventoryController(IInventoryService inventoryService) => _inventoryService = inventoryService;

    [HttpPost("process-po/{poId}")]
    public async Task<IActionResult> ProcessPO(int poId, CancellationToken ct)
    {
        await _inventoryService.ProcessPurchaseOrder(poId, ct);
        return Ok();
    }

    [HttpPost("process-sale/{saleId}")]
    public async Task<IActionResult> ProcessSale(int saleId, CancellationToken ct)
    {
        await _inventoryService.ProcessSale(saleId, ct);
        return Ok();
    }

    [HttpPost("adjust")]
    public async Task<IActionResult> AdjustStock([FromBody] StockAdjustmentRequest request, CancellationToken ct)
    {
        await _inventoryService.AdjustStock(request.VariantId, request.Quantity, request.Type, request.Reason, ct);
        return Ok();
    }

    public record StockAdjustmentRequest(int VariantId, int Quantity, StockAdjustmentType Type, string Reason);
}
