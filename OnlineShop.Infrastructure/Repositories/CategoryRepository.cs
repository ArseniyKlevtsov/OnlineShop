using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Infrastructure.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context) { }
    public async Task<Category?> GetByIdWithRelatedProductsAsync(int id) =>
        await _context.Categories.AsNoTracking().Include(c => c.Products).FirstOrDefaultAsync(c => c.CategoryId == id);
    public async Task DeleteByIdAsync(int id)
    {
        var entity = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
        if (entity != null)
        {
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }
    } 
}
