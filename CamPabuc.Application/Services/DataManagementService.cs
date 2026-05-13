using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;

namespace CamPabuc.Application.Services;

public interface IDataManagementService
{
    Task ExportDatabaseAsync(string filePath);
    Task ImportDatabaseAsync(string filePath);
    Task BackupToCloudAsync();
}

public class DataManagementService : IDataManagementService
{
    private readonly IUnitOfWork _uow;

    public DataManagementService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task ExportDatabaseAsync(string filePath)
    {
        var data = new
        {
            Manufacturers = await _uow.ManufacturerRepository.GetManufacturersAsync(default),
            ShoeModels = await _uow.ShoeModelRepository.GetShoeModelsAsync(default),
            ShoeVariants = await _uow.ShoeVariantRepository.GetVariantsAsync(default),
            PurchaseOrders = await _uow.PurchaseOrderRepository.GetPurchaseOrdersAsync(default),
            Sales = await _uow.SaleRepository.GetSalesAsync(default),
            StockAdjustments = await _uow.StockAdjustmentRepository.GetAdjustmentsAsync(default)
        };

        var json = System.Text.Json.JsonSerializer.Serialize(data, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(filePath, json);
    }

    public async Task ImportDatabaseAsync(string filePath)
    {
        throw new NotImplementedException("Full database restore from JSON requires a data migration strategy.");
    }

    public async Task BackupToCloudAsync()
    {
        await Task.Delay(1000);
    }
}
