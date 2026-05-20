using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;

namespace CamPabuc.Application.Services;

public interface IDataManagementService
{
    Task ExportDatabaseAsync(string filePath);
    Task ImportDatabaseAsync(string filePath);
    Task BackupToCloudAsync();
}

public class DataManagementService(IUnitOfWork uow) : IDataManagementService
{
    public async Task ExportDatabaseAsync(string filePath)
    {
        var data = new
        {
            Manufacturers = await uow.ManufacturerRepository.GetManufacturersAsync(default),
            ShoeModels = await uow.ShoeModelRepository.GetShoeModelsAsync(default),
            ShoeVariants = await uow.ShoeVariantRepository.GetVariantsAsync(default),
            PurchaseOrders = await uow.PurchaseOrderRepository.GetPurchaseOrdersAsync(default),
            Sales = await uow.SaleRepository.GetSalesAsync(default),
            StockAdjustments = await uow.StockAdjustmentRepository.GetAdjustmentsAsync(default)
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
