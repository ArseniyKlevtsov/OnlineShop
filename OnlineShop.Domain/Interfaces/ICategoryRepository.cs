using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetByIdWithRelatedProductsAsync(int id);
    Task DeleteByIdAsync(int id);
}
