using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Infrastructure.Repositories;

public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId)
    {
        return await _context.OrderItems.Where(oi => oi.OrderId == orderId)
                          .Include(oi => oi.Order)
                          .Include(oi => oi.Product)
                          .ToListAsync();
    }
    public async Task<IEnumerable<OrderItem>> GetByProductIdAsync(int productId)
    {
        return await _context.OrderItems.Where(oi => oi.ProductId == productId)
                           .Include(oi => oi.Order)
                           .Include(oi => oi.Product)
                           .ToListAsync();
    }
    public async Task DeleteByIdAsync(int orderItemId)
    {
        var entity = await _context.OrderItems.FirstOrDefaultAsync(c => c.OrderItemId == orderItemId);
        if (entity != null)
        {
            _context.OrderItems.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
