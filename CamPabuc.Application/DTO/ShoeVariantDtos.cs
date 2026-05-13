namespace CamPabuc.Application.DTO;

public record ShoeVariantCreateDto(
    int ShoeModelId,
    string SkuCode,
    string Size,
    string Color,
    decimal CostPrice,
    decimal RetailPrice,
    int StockQuantity
);

public record ShoeVariantUpdateDto(
    string SkuCode,
    string Size,
    string Color,
    decimal CostPrice,
    decimal RetailPrice,
    int StockQuantity
);

public record ShoeVariantListDto(
    int Id,
    string SkuCode,
    string Size,
    string Color,
    decimal RetailPrice,
    int StockQuantity
);

public record ShoeVariantDetailDto(
    int Id,
    int ShoeModelId,
    string SkuCode,
    string Size,
    string Color,
    decimal CostPrice,
    decimal RetailPrice,
    int StockQuantity
);
