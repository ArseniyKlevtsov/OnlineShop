using OnlineShop.WebApi.Middleware;

namespace OnlineShop.WebApi.Extentions;

public static class MiddlewareRegistrator
{
    public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app, bool isDevelopment)
    {
        if (isDevelopment)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        return app;
    }
}