using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartPOS.Application.Interfaces;
using SmartPOS.Infrastructure.Persistance;
using SmartPOS.Infrastructure.Repositories;

namespace SmartPOS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config, bool useInMemory = false)
    {

        if (useInMemory)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            services.AddDbContext<SmartPOSDbContext>(options =>
                options.UseSqlite(connection));
        }
        else
        {
            var cs = config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<SmartPOSDbContext>(options =>options
                .UseSqlServer(cs));
        }


        // Register your infrastructure services here
        //services.AddHealthChecks();

        services.AddScoped<SmartPOSDbContext>();
        services.AddScoped<IProductRepository, ProductRepository>();


        return services;
    }
}
