using CamPabuc.Domain.Enums;

namespace CamPabuc.Application.DTOs;

public record ContactInfoCreateDto(
    ContactInfoType ContactInfoType,
    string Value,
    bool IsDefault
);
