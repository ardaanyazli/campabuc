using CamPabuc.Domain.Enums;
namespace CamPabuc.Application.DTO;

public record ContactInfoUpdateDto(
    ContactInfoType ContactInfoType,
    string Value,
    bool IsDefault
);
