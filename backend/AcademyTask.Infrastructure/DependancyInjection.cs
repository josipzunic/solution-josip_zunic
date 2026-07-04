using AcademyTask.Application.Interfaces;
using AcademyTask.Application.Services;
using AcademyTask.Domain.Interfaces;
using AcademyTask.Domain.Interfaces.Common;
using AcademyTask.Domain.Interfaces.ExternalApi;
using AcademyTask.Domain.Interfaces.LikedProduct;
using AcademyTask.Infrastructure.ExternalApiFetch;
using AcademyTask.Infrastructure.Persistence;
using AcademyTask.Infrastructure.Persistence.Repositories.LikedProduct;
using AcademyTask.Infrastructure.Persistence.Repositories.Product;
using AcademyTask.Infrastructure.Persistence.Repositories.User;
using AcademyTask.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcademyTask.Infrastructure;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("Default")));

        services.AddScoped<DbContext>(provider => provider.GetRequiredService<AppDbContext>());
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUserService, UserService>();
        services.AddHttpClient<IExternalProductApiClient, ExternalProductApiClient>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<ILikedProductService, LikedProductService>();
        services.AddScoped<ILikedProductRepository, LikedProductRepository>();
        
        return services;
    }
}