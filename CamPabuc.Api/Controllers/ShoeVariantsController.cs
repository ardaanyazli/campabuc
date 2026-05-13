using Microsoft.AspNetCore.Mvc;
using CamPabuc.Application.Interface;
using CamPabuc.Application.DTO;
using CamPabuc.Domain.Entity;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoeVariantsController : ControllerBase
{
    private readonly IShoeVariantRepository _repo;
    public ShoeVariantsController(IShoeVariantRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct) 
        => Ok(await _repo.GetVariantsAsync(ct));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken ct) 
        => Ok(await _repo.GetVariantAsync(id, ct));

    [HttpGet("model/{modelId}")]
    public async Task<IActionResult> GetByModel(int modelId, CancellationToken ct) 
        => Ok(await _repo.GetVariantsByModelIdAsync(modelId, ct));

    [HttpPost]
    public async Task<IActionResult> Create(ShoeVariant variant, CancellationToken ct)
    {
        await _repo.CreateVariantAsync(variant, ct);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(ShoeVariant variant)
    {
        _repo.UpdateVariant(variant);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _repo.DeleteVariantAsync(id, ct);
        return Ok();
    }
}
