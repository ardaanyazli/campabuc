namespace CamPabuc.Application.DTO
{
    public record ShoeListDto(Guid id, string Barcode, decimal Price, int Stock, string Color, List<string> Genders);
}