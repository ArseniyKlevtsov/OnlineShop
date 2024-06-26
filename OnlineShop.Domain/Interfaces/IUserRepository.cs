using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserWithOrdersAsync(string userId);
}
