using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context) { }

    public async Task<User?> GetUserWithOrdersAsync(string userId)
    {
        return await _context.Users
                             .Include(u => u.Orders)
                             .ThenInclude(o => o.OrderItems)
                             .ThenInclude(oi => oi.Product)
                             .FirstOrDefaultAsync(u => u.Id == userId);
    }
}
