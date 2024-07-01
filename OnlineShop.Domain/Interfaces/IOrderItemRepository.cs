using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId, CancellationToken cancellationToken);
        Task<IEnumerable<OrderItem>> GetByProductIdAsync(int productId, CancellationToken cancellationToken);
        Task DeleteByIdAsync(int orderItemId, CancellationToken cancellationToken);
    }
}
