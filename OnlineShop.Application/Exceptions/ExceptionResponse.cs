using System.Net;

namespace OnlineShop.Application.Exceptions;

public class ExceptionResponse(HttpStatusCode httpStatusCode, string message)
{

    public string Message { get; set; } = message;
    public HttpStatusCode StatusCode { get; set; } = httpStatusCode;
}
