using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Interfaces;

public interface IProductRepository: IRepository<Product>
{
    // filters
    Task<IEnumerable<Product>> GetByCategoryAsync(Category category);
    Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);

    // includes tables
    Task<IEnumerable<Product>> GetIncludeAllAsync();
    Task<IEnumerable<Product>> GetIncludeCategoryAsync();
    Task<IEnumerable<Product>> GetIncludeOrderItemsAsync();

    // filters + includes
    Task<IEnumerable<Product>> GetByCategoryIncludeAllAsync(Category category);
    Task<IEnumerable<Product>> GetByCategoryIdIncludeAllAsync(int categoryId);

}
