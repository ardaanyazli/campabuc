namespace CamPabuc.Application.DTO;

public record SaleCreateDto(
    DateTime TransactionDate,
    decimal TotalAmount,
    decimal DiscountApplied,
    string PaymentMethod,
    IList<SaleItemCreateDto> Items
);

public record SaleItemCreateDto(
    int ShoeVariantId,
    int Quantity,
    decimal PriceAtSale
);

public record SaleListDto(
    int Id,
    DateTime TransactionDate,
    decimal TotalAmount,
    string PaymentMethod
);

public record SaleDetailDto(
    int Id,
    DateTime TransactionDate,
    decimal TotalAmount,
    decimal DiscountApplied,
    string PaymentMethod,
    IList<SaleItemDetailDto> Items
);

public record SaleItemDetailDto(
    int Id,
    int ShoeVariantId,
    int Quantity,
    decimal PriceAtSale
);
