
namespace CamPabuc.Application.Interface;

public interface IContactsUnitOfWork
{
    IContactRepository ContactRepository { get; }
    IContactInfoRepository ContactInfoRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
