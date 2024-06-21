﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IncludeStates.Extentions;
using OnlineShop.Domain.IncludeStates.Interfaces;
using OnlineShop.Domain.IncludeStates.States;
using OnlineShop.Domain.Interfaces;
using System.Linq.Expressions;


namespace OnlineShop.Infrastructure.Repositories;

public class BaseRepository<TEntity, TState> : IRepository<TEntity> 
    where TEntity : class
    where TState : IIncludeState<TEntity>
{
    protected ApplicationDbContext _context;
    protected DbSet<TEntity> _dbSet;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> GetByPerdicateAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(predicate);
    }
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public virtual async Task UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetWithIncludesAsync(TState includeState)
    {
        var query = _dbSet.AsNoTracking().AsQueryable();
        query = query.IncludeWithState(includeState);

        return await query.ToListAsync();
    }

}
