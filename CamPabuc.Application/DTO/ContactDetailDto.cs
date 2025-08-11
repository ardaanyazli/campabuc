namespace CamPabuc.Application.DTOs;

public record ContactDetailDto(Guid Id, string FullName, IList<ContactInfoDto>? ContactInfo);
