using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await _context.Orders
                                 .Include(o => o.OrderItems)
                                 .ThenInclude(oi => oi.Product)
                                 .Where(o => o.UserId == userId)
                                 .ToListAsync(cancellationToken);
        }

        public async Task<Order?> GetOrderWithDetailsAsync(int orderId, CancellationToken cancellationToken)
        {
            return await _context.Orders
                                 .Include(o => o.OrderItems)
                                 .ThenInclude(oi => oi.Product)
                                 .FirstOrDefaultAsync(o => o.OrderId == orderId, cancellationToken);
        }
    }
}
