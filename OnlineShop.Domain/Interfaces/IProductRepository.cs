using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IncludeStates;

namespace OnlineShop.Domain.Interfaces;

public interface IProductRepository: IRepository<Product>
{
    Task<IEnumerable<Product>> GetWithIncludeAsync(ProductIncludeState includeState);

    Task<IEnumerable<Product>> GetByCategoryAsync(Category category, ProductIncludeState includeState);
    Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId, ProductIncludeState includeState);

}
