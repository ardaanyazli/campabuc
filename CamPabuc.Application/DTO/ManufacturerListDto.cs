namespace CamPabuc.Application.DTO;

public record ManufacturerListDto(
    Guid Id,
    string Name,
    string Phone,
    bool IsActive
);