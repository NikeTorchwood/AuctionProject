using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EntityFramework;

public static class EntityFrameworkInstaller
{
    public static IServiceCollection ConfigureContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DatabaseContext>(
            //opt => opt.UseNpgsql(connectionString));
            opt => opt.UseInMemoryDatabase(connectionString));
        return services;
    }
}

