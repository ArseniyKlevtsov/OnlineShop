using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Infrastructure.Repositories;

public class BaseRepository<TEntity, Tkey> : IBaseRepository<TEntity, Tkey> 
    where TEntity : class
{
    DbContext _context;
    DbSet<TEntity> _dbSet;

    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    public virtual async Task<TEntity?> Get(Tkey key)
    {
        return await _dbSet.FindAsync(key);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async void Add(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public virtual async void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public virtual async void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

}
