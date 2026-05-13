using Microsoft.AspNetCore.Mvc;
using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchaseOrdersController : ControllerBase
{
    private readonly IPurchaseOrderRepository _repo;
    public PurchaseOrdersController(IPurchaseOrderRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct) => Ok(await _repo.GetPurchaseOrdersAsync(ct));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken ct) => Ok(await _repo.GetPurchaseOrderAsync(id, ct));

    [HttpPost]
    public async Task<IActionResult> Create(PurchaseOrder po, CancellationToken ct)
    {
        await _repo.CreatePurchaseOrderAsync(po, ct);
        return Ok(po);
    }

    [HttpPut]
    public IActionResult Update(PurchaseOrder po)
    {
        _repo.UpdatePurchaseOrder(po);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _repo.DeletePurchaseOrderAsync(id, ct);
        return Ok();
    }
}
