using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IncludeStates.Interfaces;
using OnlineShop.Domain.IncludeStates.States;

namespace OnlineShop.Domain.IncludeStates.Extentions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity>? IncludeWithState<TEntity, TState>(this IQueryable<TEntity> query, TState includeState)
        where TEntity : class
        where TState : IIncludeState<TEntity>
    {
        switch (includeState)
        {
            case ProductIncludeState productIncludeState:
                return ((IQueryable<Product>)query).IncludeWithState(productIncludeState) as IQueryable<TEntity>;

            // add more states
            default:
                return query;
        }
    }
}