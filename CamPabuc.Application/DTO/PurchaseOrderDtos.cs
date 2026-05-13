namespace CamPabuc.Application.DTO;

public record PurchaseOrderCreateDto(
    int ManufacturerId,
    DateOnly OrderDate,
    DateOnly ExpectedDate,
    IList<POItemCreateDto> Items
);

public record POItemCreateDto(
    int ShoeVariantId,
    int QuantityOrdered,
    int QuantityReceived
);

public record PurchaseOrderListDto(
    int Id,
    int ManufacturerId,
    DateOnly OrderDate,
    string Status
);

public record PurchaseOrderDetailDto(
    int Id,
    int ManufacturerId,
    DateOnly OrderDate,
    DateOnly ExpectedDate,
    string Status,
    IList<POItemDetailDto> Items
);

public record POItemDetailDto(
    int Id,
    int ShoeVariantId,
    int QuantityOrdered,
    int QuantityReceived
);
