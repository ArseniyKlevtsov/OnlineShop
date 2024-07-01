using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.FluentValidation.UserValidators;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Mapping;
using OnlineShop.Application.Services;
using OnlineShop.Application.Servises;
using OnlineShop.Infrastructure.Configurations;
using System.Text;

namespace OnlineShop.WebApi.Extentions;

public static class ServiceRegistrator
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddInfrastructure(configuration);
        services.AddJWTAuth(configuration);

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(typeof(CreateUserRequestDtoValidator).Assembly);

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();

        services.AddAutoMapper(typeof(UserProfile).Assembly);

        return services;
    }

    private static IServiceCollection AddJWTAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            };
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Admin"));
            options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
            options.AddPolicy("RequireAdminOrUser", policy => policy.RequireRole("Admin", "User"));
        });
        return services;
    }
}