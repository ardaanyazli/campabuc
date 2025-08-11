using CamPabuc.Domain.Enums;

namespace CamPabuc.Application.DTO;

public record ContactInfoCreateDto(
    ContactInfoType ContactInfoType,
    string Value,
    bool IsDefault
);
