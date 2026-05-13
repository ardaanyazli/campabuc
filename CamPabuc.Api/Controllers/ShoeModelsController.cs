using Microsoft.AspNetCore.Mvc;
using CamPabuc.Application.Interface;
using CamPabuc.Application.DTO;
using CamPabuc.Domain.Entity;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoeModelsController : ControllerBase
{
    private readonly IShoeModelRepository _repo;
    public ShoeModelsController(IShoeModelRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct) 
        => Ok(await _repo.GetShoeModelsAsync(ct));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken ct) 
        => Ok(await _repo.GetShoeModelAsync(id, ct));

    [HttpPost]
    public async Task<IActionResult> Create(ShoeModel model, CancellationToken ct)
    {
        await _repo.CreateShoeModelAsync(model, ct);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(ShoeModel model)
    {
        _repo.UpdateShoeModel(model);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _repo.DeleteShoeModelAsync(id, ct);
        return Ok();
    }
}
