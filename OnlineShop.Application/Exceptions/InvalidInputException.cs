namespace OnlineShop.Application.Exception
{
    public class InvalidInputException : ApplicationException
    {
        public InvalidInputException(string message) : base(message) { }
    }
}
