using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IncludeStates.States;

namespace OnlineShop.Domain.IncludeStates.Extentions;

public static class ProductIncludeExtensions
{
    public static IQueryable<Product> IncludeWithState(this IQueryable<Product> query, ProductIncludeState includeState)
    {
        if (includeState.IncludeOrderItems)
        {
            query = query.Include(p => p.OrderItems);
        }

        if (includeState.IncludeCategory)
        {
            query = query.Include(p => p.Category);
        }

        return query;
    }
}