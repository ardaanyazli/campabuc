using MessagePack;
namespace campabuc.api.Models.DTO;

[MessagePackObject]
public class ManufacturerDto
{
    [Key(0)]
    public int Id { get; set; }

    [Key(1)]
    public string Name { get; set; }

    [Key(2)]
    public string Address { get; set; }

    [Key(3)]
    public string Phone { get; set; }

    [Key(4)]
    public string ContactName { get; set; }

    [Key(5)]
    public string CreatedAt { get; set; }

    [Key(6)]
    public string UpdatedAt { get; set; }

    [Key(7)]
    public string DeletedAt { get; set; }
}
