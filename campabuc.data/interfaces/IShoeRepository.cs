using campabuc.model;

namespace campabuc.data.interfaces;
public interface IShoeRepository : IRepository<Shoe>
{
    public Task<int> AddShoe();
    public Task<bool> UpdateShoe();
    public Task<bool> DeleteShoe();
}

