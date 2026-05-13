namespace CamPabuc.Domain.Entity;
public class ShoeCategory : BaseEntity, IHasIntKey
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public IList<ShoeModel>? ShoeModels { get; set; }
}
