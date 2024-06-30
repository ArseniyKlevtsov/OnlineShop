namespace OnlineShop.Application.Exceptions
{
    public class UnauthorizedAccessException : ApplicationException
    {
        public UnauthorizedAccessException(string message) : base(message) { }
    }
}
