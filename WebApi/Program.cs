using OnlineShop.Infrastructure.Configurations;
using OnlineShop.WebApi.Extentions;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        builder.Services.AddInfrastructure(builder.Configuration);

        var app = builder.Build();

        app.UseMiddlewares(app.Environment.IsDevelopment());

        app.MapControllers();

        app.Run();
    }
}