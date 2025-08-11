namespace CamPabuc.Application.DTO;

public record ContactCreateDto(
    string FirstName,
    string LastName,
    IList<ContactInfoCreateDto>? ContactInfo
);
