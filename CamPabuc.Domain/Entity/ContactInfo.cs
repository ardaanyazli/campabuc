using CamPabuc.Domain.Enums;

namespace  CamPabuc.Domain.Entity;

public class ContactInfo
{
    public Guid Id { get; set; }
    public DateOnly CreatedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public ContactInfoType InfoType { get; set; }
    public string Value { get; set; } = default!;
    public Guid ContactId { get; set; }
    public Contact Contact { get; set; } = default!;
}