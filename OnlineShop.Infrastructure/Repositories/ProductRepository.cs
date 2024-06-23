using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.IncludeStates;
using OnlineShop.Domain.Extensions;

namespace OnlineShop.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Product>> GetWithIncludeAsync(ProductIncludeState includeState)
    {
        return await _dbSet
            .AsNoTracking()
            .IncludeWithState(includeState)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(Category category, ProductIncludeState includeState)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(p => p.CategoryId == category.CategoryId)
            .IncludeWithState(includeState)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId, ProductIncludeState includeState)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(p => p.CategoryId == categoryId)
            .IncludeWithState(includeState)
            .ToListAsync();
    }

}
