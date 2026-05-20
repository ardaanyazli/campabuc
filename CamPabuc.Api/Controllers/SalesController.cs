using Microsoft.AspNetCore.Mvc;
using CamPabuc.Application.Interface;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController(ISaleRepository repo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct) => Ok(await repo.GetSalesAsync(ct));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken ct) => Ok(await repo.GetSaleAsync(id, ct));
}
