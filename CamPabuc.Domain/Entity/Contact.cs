namespace CamPabuc.Domain.Entity;

public class Contact : BaseEntity, IHasGuidKey
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public IList<ContactInfo>? ContactInfos { get; set; }
}
