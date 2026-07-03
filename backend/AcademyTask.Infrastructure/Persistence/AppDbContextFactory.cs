using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AcademyTask.Infrastructure.Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        DotNetEnv.Env.TraversePath().Load();
        string? connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
        
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("Please set the environment variable DATABASE_URL");
            
        
        
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString);
        
        return new AppDbContext(optionsBuilder.Options);
    }
}