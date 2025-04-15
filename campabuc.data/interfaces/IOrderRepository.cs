using campabuc.model;

namespace campabuc.data.interfaces;
public interface IOrderRepository : IRepository<Order>
{
    public Task<int> AddOrder();
    public Task<bool> UpdateOrder();
    public Task<bool> DeleteOrder();
}

