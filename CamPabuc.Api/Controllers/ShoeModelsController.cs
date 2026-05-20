using Microsoft.AspNetCore.Mvc;
using CamPabuc.Application.Interface;
using CamPabuc.Application.DTO;
using CamPabuc.Domain.Entity;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoeModelsController(IShoeModelRepository repo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct) 
        => Ok(await repo.GetShoeModelsAsync(ct));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken ct) 
        => Ok(await repo.GetShoeModelAsync(id, ct));

    [HttpPost]
    public async Task<IActionResult> Create(ShoeModel model, CancellationToken ct)
    {
        await repo.CreateShoeModelAsync(model, ct);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(ShoeModel model)
    {
        repo.UpdateShoeModel(model);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await repo.DeleteShoeModelAsync(id, ct);
        return Ok();
    }
}
