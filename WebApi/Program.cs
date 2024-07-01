using OnlineShop.WebApi.Extentions;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddServices(builder.Configuration);

        var app = builder.Build();
        app.UseMiddlewares(app.Environment.IsDevelopment());
        app.MapControllers();

        app.Run();
    }
}