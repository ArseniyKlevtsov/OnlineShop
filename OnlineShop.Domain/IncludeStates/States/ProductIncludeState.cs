using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IncludeState;
using OnlineShop.Domain.IncludeStates.Interfaces;

namespace OnlineShop.Domain.IncludeStates.States;

public class ProductIncludeState : IIncludeState<Product>
{
    public bool IncludeOrderItems { get; set; }
    public bool IncludeCategory { get; set; }

    public ProductIncludeState()
    {
        IncludeOrderItems = false;
        IncludeCategory = false;
    }

    public void IncludeTable(TableNames tableName)
    {
        switch (tableName)
        {
            case TableNames.OrderItem:
                IncludeOrderItems = true;
                break;
            case TableNames.Categories:
                IncludeCategory = true;
                break;
        }
    }
}
