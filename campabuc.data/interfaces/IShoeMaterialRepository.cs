using campabuc.model;

namespace campabuc.data.interfaces;
public interface IShoeMaterialRepository : IRepository<ShoeMaterial>
{
    public Task<int> AddShoeMaterial();
    public Task<bool> UpdateShoeMaterial();
    public Task<bool> DeleteShoeMaterial();
}

