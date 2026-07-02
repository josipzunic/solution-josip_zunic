using AcademyTask.Domain.Interfaces;
using AcademyTask.Infrastructure.Persistence;
using AcademyTask.Infrastructure.Persistence.Repositories.Product;
using AcademyTask.Infrastructure.Persistence.Repositories.User;
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
        
        return services;
    }
}