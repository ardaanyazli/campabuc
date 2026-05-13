using Microsoft.AspNetCore.Mvc;
using CamPabuc.Application.Services;
using CamPabuc.Domain.Entity;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CheckoutController : ControllerBase
{
    private readonly ICheckoutService _checkoutService;
    public CheckoutController(ICheckoutService checkoutService) => _checkoutService = checkoutService;

    [HttpPost("calculate")]
    public IActionResult Calculate([FromBody] CalculationRequest request)
    {
        var subtotal = _checkoutService.CalculateSubtotal(request.Items);
        var discount = _checkoutService.ApplyDiscount(subtotal, request.DiscountPercent, request.FixedDiscount);
        var total = _checkoutService.CalculateTotal(subtotal, request.TaxRate, discount);
        
        return Ok(new { Subtotal = subtotal, Discount = discount, Total = total });
    }

    [HttpPost("finalize")]
    public async Task<IActionResult> Finalize(Sale sale, CancellationToken ct)
    {
        await _checkoutService.FinalizeSale(sale, ct);
        return Ok();
    }

    public record CalculationRequest(
        IList<SaleItem> Items, 
        decimal DiscountPercent, 
        decimal FixedDiscount, 
        decimal TaxRate
    );
}
