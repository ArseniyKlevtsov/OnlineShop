namespace OnlineShop.Application.Exceptions.AuthExceptions;
public class RegistrationException : Exception
{
    public RegistrationException(string message) : base(message)
    {
    }

    public RegistrationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public IEnumerable<string> Errors { get; set; } = new List<string>();
}