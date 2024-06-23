using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IncludeStates;

namespace OnlineShop.Domain.Extensions;

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