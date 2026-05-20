using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Domain.Enums;

namespace CamPabuc.Application.Services;

public interface IInventoryService
{
    Task ProcessPurchaseOrder(int poId, CancellationToken ct);
    Task ProcessSale(int saleId, CancellationToken ct);
    Task AdjustStock(int variantId, int quantity, StockAdjustmentType type, string reason, CancellationToken ct);
}

public class InventoryService(
    IPurchaseOrderRepository poRepo,
    IShoeVariantRepository variantRepo,
    ISaleRepository saleRepo,
    IStockAdjustmentRepository adjustmentRepo,
    IUnitOfWork unitOfWork) : IInventoryService
{
    public async Task ProcessPurchaseOrder(int poId, CancellationToken ct)
    {
        var po = await poRepo.GetPurchaseOrderAsync(poId, ct);
        if (po == null) throw new Exception("Purchase Order not found");

        foreach (var item in po.Items ?? [])
        {
            var variant = await variantRepo.GetVariantAsync(item.ShoeVariantId, ct);
            if (variant == null) continue;

            variant.StockQuantity += item.QuantityReceived;
            variantRepo.UpdateVariant(variant);
        }

        po.Status = PurchaseOrderStatus.Received;
        poRepo.UpdatePurchaseOrder(po);
        await unitOfWork.SaveChangesAsync(ct);
    }

    public async Task ProcessSale(int saleId, CancellationToken ct)
    {
        var sale = await saleRepo.GetSaleAsync(saleId, ct);
        if (sale == null) throw new Exception("Sale not found");

        foreach (var item in sale.Items ?? [])
        {
            var variant = await variantRepo.GetVariantAsync(item.ShoeVariantId, ct);
            if (variant == null) throw new Exception($"Variant {item.ShoeVariantId} not found");
            if (variant.StockQuantity < item.Quantity) throw new Exception("Insufficient stock");

            variant.StockQuantity -= item.Quantity;
            variantRepo.UpdateVariant(variant);
        }

        await unitOfWork.SaveChangesAsync(ct);
    }

    public async Task AdjustStock(int variantId, int quantity, StockAdjustmentType type, string reason, CancellationToken ct)
    {
        var variant = await variantRepo.GetVariantAsync(variantId, ct);
        if (variant == null) throw new Exception("Variant not found");

        // Returns increase stock, others (Damage/Exchange) usually decrease or neutral
        int change = type == StockAdjustmentType.Return ? quantity : -quantity;
        variant.StockQuantity += change;
        
        var adjustment = new StockAdjustment 
        { 
            ShoeVariantId = variantId, 
            Quantity = quantity, 
            Type = type, 
            Reason = reason, 
            Date = DateOnly.FromDateTime(DateTime.Now) 
        };

        variantRepo.UpdateVariant(variant);
        await adjustmentRepo.CreateAdjustmentAsync(adjustment, ct);
        await unitOfWork.SaveChangesAsync(ct);
    }
}
