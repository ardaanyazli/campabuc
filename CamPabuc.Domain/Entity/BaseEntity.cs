namespace CamPabuc.Domain.Entity;
public abstract class BaseEntity
{
    public DateOnly CreatedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }
    public bool IsActive { get; set; }
}

