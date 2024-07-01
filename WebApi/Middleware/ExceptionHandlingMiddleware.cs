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

            // Product Service
            ProductNotFoundException ex => new ExceptionResponse(HttpStatusCode.NotFound, ex.Message),
            ProductOperationException ex => new ExceptionResponse(HttpStatusCode.BadRequest, ex.Message),
            
            // Auth Service
            UserNotFoundException ex => new ExceptionResponse(HttpStatusCode.NotFound, exception.Message),
            
            // unexpected exception
            _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Internal server error. Please retry later.")
        }; 

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)response.StatusCode;
        await context.Response.WriteAsJsonAsync(response);
    }
}
