using CamPabuc.Domain.Enums;

namespace CamPabuc.Application.DTO;

public record ShoeUpdateDto(
    string Barcode,
    ShoeGender Gender,
    decimal Price,
    string Color,
    string? Description,
    int Stock,
    Guid? ManufacturerId,
    Guid? CategoryId,
    bool IsActive
);