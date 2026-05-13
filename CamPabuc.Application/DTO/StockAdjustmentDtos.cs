namespace CamPabuc.Application.DTO;

public record StockAdjustmentCreateDto(
    int ShoeVariantId,
    int Quantity,
    int AdjustmentType, // Maps to StockAdjustmentType enum
    string Reason,
    DateOnly Date
);

public record StockAdjustmentListDto(
    int Id,
    int ShoeVariantId,
    string Type,
    int Quantity,
    DateOnly Date,
    string Reason
);
