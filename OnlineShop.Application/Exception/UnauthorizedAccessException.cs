namespace OnlineShop.Application.Exception
{
    public class UnauthorizedAccessException : ApplicationException
    {
        public UnauthorizedAccessException(string message) : base(message) { }
    }
}
