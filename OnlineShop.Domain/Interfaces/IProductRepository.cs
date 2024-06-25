using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IncludeStates;
using System.Linq.Expressions;

namespace OnlineShop.Domain.Interfaces;

public interface IProductRepository: IRepository<Product>
{
    Task<IEnumerable<Product>> GetWithIncludeAsync(ProductIncludeState includeState);

    Task<IEnumerable<Product>> GetWithIncludeByPredicateAsync(Expression<Func<Product, bool>> predicate, ProductIncludeState includeState);

}
