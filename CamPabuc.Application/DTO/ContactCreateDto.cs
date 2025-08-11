namespace CamPabuc.Application.DTOs;

public record ContactCreateDto(
    string FirstName,
    string LastName,
    IList<ContactInfoCreateDto>? ContactInfo
);