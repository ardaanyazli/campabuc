using Microsoft.AspNetCore.Mvc;
using CamPabuc.Application.Interface;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ISaleRepository _repo;
    public SalesController(ISaleRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct) => Ok(await _repo.GetSalesAsync(ct));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken ct) => Ok(await _repo.GetSaleAsync(id, ct));
}
