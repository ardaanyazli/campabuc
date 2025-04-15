using campabuc.model;

namespace campabuc.data.interfaces;
public interface IOrderItemRepository : IRepository<OrderItem>
{
    public Task<int> AddOrderItem();
    public Task<bool> UpdateOrderItem();
    public Task<bool> DeleteOrderItem();
}

