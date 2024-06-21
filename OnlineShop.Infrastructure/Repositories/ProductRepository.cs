using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context) { }

    // filters
    public async Task<IEnumerable<Product>> GetByCategoryAsync(Category category)
    {
        return await _dbSet
            .Where(p => p.CategoryId == category.CategoryId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
    {
        return await _dbSet
            .Where(p => p.CategoryId == categoryId)
            .AsNoTracking()
            .ToListAsync();
    }

    // includes tables
    public async Task<IEnumerable<Product>> GetIncludeAllAsync()
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.OrderItems)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<IEnumerable<Product>> GetIncludeCategoryAsync()
    {
        return await _dbSet
            .Include(p => p.Category)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetIncludeOrderItemsAsync()
    {
        return await _dbSet
            .Include(p => p.OrderItems)
            .AsNoTracking()
            .ToListAsync();
    }

    // filters + includes

    public async Task<IEnumerable<Product>> GetByCategoryIncludeAllAsync(Category category)
    {
        return await _dbSet
            .Where(p => p.CategoryId == category.CategoryId)
            .Include(p => p.Category)
            .Include(p => p.OrderItems)
            .ToListAsync();
    }
    public async Task<IEnumerable<Product>> GetByCategoryIdIncludeAllAsync(int categoryId)
    {
        return await _dbSet
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.Category)
            .Include(p => p.OrderItems)
            .ToListAsync();
    }

}
