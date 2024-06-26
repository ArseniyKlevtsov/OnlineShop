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
        return await _dbSet
            .AsNoTracking()
            .Where(orderItem => orderItem.OrderId == orderId)
            .Include(orderItem => orderItem.Order)
            .Include(orderItem => orderItem.Product)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderItem>> GetByProductIdAsync(int productId)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(orderItem => orderItem.ProductId == productId)
            .Include(orderItem => orderItem.Order)
            .Include(orderItem => orderItem.Product)
            .ToListAsync();
    }
    public async Task DeleteByIdAsync(int orderItemId)
    {
        var entity = await _context.OrderItems.FirstOrDefaultAsync(c => c.OrderItemId == orderItemId);
        _context.OrderItems.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
