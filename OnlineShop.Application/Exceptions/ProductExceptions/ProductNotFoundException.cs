namespace OnlineShop.Application.Exceptions.ProductExceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string message, int productId)
        : base(message)
    {
        ProductId = productId;
    }

    public int ProductId { get; }
}