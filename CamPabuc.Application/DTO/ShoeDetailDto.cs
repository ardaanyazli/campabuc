using CamPabuc.Domain.Enums;

namespace CamPabuc.Application.DTO;

public record ShoeDetailDto(
    Guid Id,
    string Barcode,
    ShoeGender Gender,
    decimal Price,
    string Color,
    string? Description,
    int Stock,
    Guid? ManufacturerId,
    Guid? CategoryId,
    DateOnly CreatedAt,
    DateOnly UpdatedAt,
    bool IsActive
);