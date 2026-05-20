using Microsoft.AspNetCore.Mvc;
using CamPabuc.Application.Interface;
using CamPabuc.Application.DTO;
using CamPabuc.Domain.Entity;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoeVariantsController(IShoeVariantRepository repo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct) 
        => Ok(await repo.GetVariantsAsync(ct));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken ct) 
        => Ok(await repo.GetVariantAsync(id, ct));

    [HttpGet("model/{modelId}")]
    public async Task<IActionResult> GetByModel(int modelId, CancellationToken ct) 
        => Ok(await repo.GetVariantsByModelIdAsync(modelId, ct));

    [HttpPost]
    public async Task<IActionResult> Create(ShoeVariant variant, CancellationToken ct)
    {
        await repo.CreateVariantAsync(variant, ct);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(ShoeVariant variant)
    {
        repo.UpdateVariant(variant);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await repo.DeleteVariantAsync(id, ct);
        return Ok();
    }
}
