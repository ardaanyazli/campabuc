using Microsoft.AspNetCore.Mvc;
using CamPabuc.Application.Services;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataManagementController : ControllerBase
{
    private readonly IDataManagementService _dataManagementService;
    public DataManagementController(IDataManagementService dataManagementService) => _dataManagementService = dataManagementService;

    [HttpPost("export")]
    public async Task<IActionResult> Export([FromBody] ExportRequest request, CancellationToken ct)
    {
        await _dataManagementService.ExportDatabaseAsync(request.FilePath);
        return Ok();
    }

    [HttpPost("import")]
    public async Task<IActionResult> Import([FromBody] ImportRequest request, CancellationToken ct)
    {
        await _dataManagementService.ImportDatabaseAsync(request.FilePath);
        return Ok();
    }

    [HttpPost("backup")]
    public async Task<IActionResult> Backup(CancellationToken ct)
    {
        await _dataManagementService.BackupToCloudAsync();
        return Ok();
    }

    public record ExportRequest(string FilePath);
    public record ImportRequest(string FilePath);
}
