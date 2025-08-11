namespace CamPabuc.Application.DTO;

public record ManufacturerUpdateDto(
    string Name,
    string Phone,
    string Address,
    bool IsActive
);