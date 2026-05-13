namespace CamPabuc.Application.DTO;

public record ShoeModelCreateDto(
    string Name,
    string Brand,
    string BaseMaterial,
    string? Description,
    int ManufacturerId,
    int ShoeCategoryId
);

public record ShoeModelUpdateDto(
    string Name,
    string Brand,
    string BaseMaterial,
    string? Description,
    int ManufacturerId,
    int ShoeCategoryId
);

public record ShoeModelListDto(
    int Id,
    string Name,
    string Brand,
    string BaseMaterial
);

public record ShoeModelDetailDto(
    int Id,
    string Name,
    string Brand,
    string BaseMaterial,
    string? Description,
    int ManufacturerId,
    int ShoeCategoryId
);
