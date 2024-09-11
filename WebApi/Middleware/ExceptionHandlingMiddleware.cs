using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Exceptions.ProductExceptions;
using OnlineShop.Application.Exceptions.AuthExceptions;
using System.Net;

namespace OnlineShop.WebApi.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        ExceptionResponse response = exception switch
        {
            // Auth
            RegistrationException ex => new ExceptionResponse(HttpStatusCode.BadRequest, ex.Message),
            UserNotFoundException ex => new ExceptionResponse(HttpStatusCode.NotFound, ex.Message),

            // Product
            ProductOperationException ex => new ExceptionResponse(HttpStatusCode.BadRequest, ex.Message),

            // Base
            AlreadyExistException ex => new ExceptionResponse(HttpStatusCode.Conflict, ex.Message),
            InvalidInputException ex => new ExceptionResponse(HttpStatusCode.BadRequest, ex.Message),
            NotFoundException ex => new ExceptionResponse(HttpStatusCode.NotFound, ex.Message),
            Application.Exceptions.UnauthorizedAccessException ex => new ExceptionResponse(HttpStatusCode.Unauthorized, ex.Message),

            // unexpected exception
            _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Internal server error. Please retry later." + exception.Message)
        }; 

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)response.StatusCode;
        await context.Response.WriteAsJsonAsync(response);
    }
}
