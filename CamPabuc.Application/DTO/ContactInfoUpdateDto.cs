using CamPabuc.Domain.Enums;

public record ContactInfoUpdateDto(
    ContactInfoType ContactInfoType,
    string Value,
    bool IsDefault
);