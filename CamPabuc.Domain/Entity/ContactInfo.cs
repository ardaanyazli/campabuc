using CamPabuc.Domain.Enums;

namespace CamPabuc.Domain.Entity;

public class ContactInfo : BaseEntity, IHasGuidKey
{
    public Guid Id { get; set; }
    public ContactInfoType InfoType { get; set; }
    public string Value { get; set; } = default!;
    public Guid ContactId { get; set; }
    public Contact Contact { get; set; } = default!;
}
