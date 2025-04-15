using campabuc.model;

namespace campabuc.data.interfaces;
public interface IShoeSizeRepository : IRepository<ShoeSize>
{
    public Task<int> AddShoeSize();
    public Task<bool> UpdateShoeSize();
    public Task<bool> DeleteShoeSize();
}

