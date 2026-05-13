using CamPabuc.Domain.Entity;

namespace CamPabuc.Application.Extensions;
public static class BarcodeGenerator
{
    public static string GenerateBarcode(this ShoeVariant entity)
    {
        // In a real scenario, this would use bwip-js or similar to generate a barcode string/image
        // For now, we generate a unique SKU-based string
        return $"SKU-{entity.SkuCode}-{entity.Id}";
    }
}
