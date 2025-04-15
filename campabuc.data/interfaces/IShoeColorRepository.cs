using campabuc.model;

namespace campabuc.data.interfaces;
public interface IShoeColorRepository : IRepository<ShoeColor>
{
    public Task<int> AddShoeColor();
    public Task<bool> UpdateShoeColor();
    public Task<bool> DeleteShoeColor();
}

