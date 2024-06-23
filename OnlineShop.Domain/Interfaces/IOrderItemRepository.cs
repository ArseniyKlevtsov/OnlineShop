using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces;

public interface IOrderItemRepository : IRepository<OrderItem>
{
    Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId);
    Task<IEnumerable<OrderItem>> GetByProductIdAsync(int productId);
    Task DeleteByIdAsync(int orderItemId);
}
