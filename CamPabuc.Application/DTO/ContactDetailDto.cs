namespace CamPabuc.Application.DTO;

public record ContactDetailDto(Guid Id, string FullName, IList<ContactInfoDto>? ContactInfo);
