using MessagePack;
namespace campabuc.api.Models.DTO;

[MessagePackObject]
public class ShoeDto
{
    [Key(0)]
    public string Id { get; set; }

    [Key(1)]
    public byte Category { get; set; }

    [Key(2)]
    public int Color { get; set; }

    [Key(3)]
    public int Size { get; set; }

    [Key(4)]
    public int Material { get; set; }

    [Key(5)]
    public int Inventory { get; set; }

    [Key(6)]
    public decimal Price { get; set; }

    [Key(7)]
    public string Barcode { get; set; }

    [Key(8)]
    public string ImageUrl { get; set; }

    [Key(9)]
    public string CreatedAt { get; set; }

    [Key(10)]
    public string UpdatedAt { get; set; }

    [Key(11)]
    public string DeletedAt { get; set; }
}



