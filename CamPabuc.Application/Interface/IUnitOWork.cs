namespace CamPabuc.Application.Interface;

public interface IUnitOfWork
{
    IShoeRepository ShoeRepository { get; }
    IManufacturerRepository ManufacturerRepository { get; }
    IContactRepository ContactRepository { get; }
    IContactInfoRepository ContactInfoRepository { get; }
    IShoeCategoryRepository ShoeCategoryRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
