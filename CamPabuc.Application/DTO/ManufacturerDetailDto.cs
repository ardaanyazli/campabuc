namespace CamPabuc.Application.DTO;

public record ManufacturerDetailDto(
    Guid Id,
    string Name,
    string Phone,
    string Address,
    DateOnly CreatedAt,
    DateOnly UpdatedAt,
    bool IsActive
);