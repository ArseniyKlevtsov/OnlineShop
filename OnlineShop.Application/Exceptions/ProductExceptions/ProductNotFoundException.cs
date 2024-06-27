namespace OnlineShop.Application.Exceptions.ProductExceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(int productId)
        : base($"Product with ID {productId} not found.")
    {
        ProductId = productId;
    }

    public int ProductId { get; }
}