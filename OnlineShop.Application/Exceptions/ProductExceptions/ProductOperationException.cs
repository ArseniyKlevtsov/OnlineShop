namespace OnlineShop.Application.Exceptions.ProductExceptions;

public class ProductOperationException : Exception
{
    public ProductOperationException(string message)
        : base(message)
    {
    }

    public ProductOperationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}