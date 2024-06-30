using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId, CancellationToken cancellationToken);
        Task<Order?> GetOrderWithDetailsAsync(int orderId, CancellationToken cancellationToken);
    }
}
