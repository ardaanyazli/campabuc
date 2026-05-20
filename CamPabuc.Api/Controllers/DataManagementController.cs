using Microsoft.AspNetCore.Mvc;
using CamPabuc.Application.Services;

namespace CamPabuc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataManagementController(IDataManagementService dataManagementService) : ControllerBase
{
    [HttpPost("export")]
    public async Task<IActionResult> Export([FromBody] ExportRequest request, CancellationToken ct)
    {
        await dataManagementService.ExportDatabaseAsync(request.FilePath);
        return Ok();
    }

    [HttpPost("import")]
    public async Task<IActionResult> Import([FromBody] ImportRequest request, CancellationToken ct)
    {
        await dataManagementService.ImportDatabaseAsync(request.FilePath);
        return Ok();
    }

    [HttpPost("backup")]
    public async Task<IActionResult> Backup(CancellationToken ct)
    {
        await dataManagementService.BackupToCloudAsync();
        return Ok();
    }

    public record ExportRequest(string FilePath);
    public record ImportRequest(string FilePath);
}
