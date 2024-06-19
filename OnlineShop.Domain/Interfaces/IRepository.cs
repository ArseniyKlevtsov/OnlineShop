namespace OnlineShop.Domain.Interfaces;

public interface IRepository<TEntity, TKey> 
    where TEntity : class
{
    Task<TEntity?> Get(TKey key);
    Task<IEnumerable<TEntity>> GetAll();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
