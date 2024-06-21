using System.Linq.Expressions;

namespace OnlineShop.Domain.Interfaces;

public interface IRepository<TEntity> 
    where TEntity : class
{
    Task<TEntity?> GetByPerdicateAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}
