using OnlineShop.Domain.IncludeState;

namespace OnlineShop.Domain.IncludeStates.Interfaces;

public interface IIncludeState<out TEntity>
{
    void IncludeTable(TableNames tableName);
}
