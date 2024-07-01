using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.IncludeStates;
using OnlineShop.Domain.Extensions;
using System.Linq.Expressions;

namespace OnlineShop.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Product>> GetWithIncludeAsync(ProductIncludeState includeState, CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetWithIncludeByPredicateAsync(Expression<Func<Product, bool>> predicate, ProductIncludeState includeState, CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

}
