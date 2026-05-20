using Microsoft.AspNetCore.Mvc;
using CamPabuc.Application.Services;
using CamPabuc.Domain.Entity;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CheckoutController(ICheckoutService checkoutService) : ControllerBase
{
    [HttpPost("calculate")]
    public IActionResult Calculate([FromBody] CalculationRequest request)
    {
        var subtotal = checkoutService.CalculateSubtotal(request.Items);
        var discount = checkoutService.ApplyDiscount(subtotal, request.DiscountPercent, request.FixedDiscount);
        var total = checkoutService.CalculateTotal(subtotal, request.TaxRate, discount);
        
        return Ok(new { Subtotal = subtotal, Discount = discount, Total = total });
    }

    [HttpPost("finalize")]
    public async Task<IActionResult> Finalize(Sale sale, CancellationToken ct)
    {
        await checkoutService.FinalizeSale(sale, ct);
        return Ok();
    }

    public record CalculationRequest(
        IList<SaleItem> Items, 
        decimal DiscountPercent, 
        decimal FixedDiscount, 
        decimal TaxRate
    );
}
