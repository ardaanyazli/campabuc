using CamPabuc.Application.DTO;
using CamPabuc.Domain.Entity;

namespace CamPabuc.Application.Extensions;
public static class MapperExtensions
{
    public static ShoeDetailDto ToDetailDto(this Shoe entity)
    {
        return new ShoeDetailDto(entity.Id,
                entity.Barcode,
                entity.Gender,
                entity.Price,
                entity.Color,
                entity.Description,
                entity.Stock,
                entity.ManufacturerId,
                entity.ShoeCategoryId,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.IsActive);
    }

    public static ShoeListDto ToListDto(this Shoe entity)
    {
        return new ShoeListDto(entity.Id,
                entity.Barcode,
                entity.Price,
                entity.Stock,
                entity.Color,
                entity.Gender.ToString()
                );
    }

    public static Shoe ToEntity(this ShoeCreateDto dto)
    {
        return new Shoe()
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow),
            IsActive = true,
            Barcode =

        }

    }





}
