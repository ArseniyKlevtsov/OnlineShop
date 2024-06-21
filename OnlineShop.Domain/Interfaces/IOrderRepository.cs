using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
    Task<Order> GetOrderWithDetailsAsync(int orderId);
}
