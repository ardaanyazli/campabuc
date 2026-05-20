using Microsoft.AspNetCore.Mvc;
using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchaseOrdersController(IPurchaseOrderRepository repo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct) => Ok(await repo.GetPurchaseOrdersAsync(ct));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken ct) => Ok(await repo.GetPurchaseOrderAsync(id, ct));

    [HttpPost]
    public async Task<IActionResult> Create(PurchaseOrder po, CancellationToken ct)
    {
        await repo.CreatePurchaseOrderAsync(po, ct);
        return Ok(po);
    }

    [HttpPut]
    public IActionResult Update(PurchaseOrder po)
    {
        repo.UpdatePurchaseOrder(po);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await repo.DeletePurchaseOrderAsync(id, ct);
        return Ok();
    }
}
