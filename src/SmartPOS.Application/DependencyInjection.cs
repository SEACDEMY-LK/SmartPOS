using Microsoft.Extensions.DependencyInjection;

namespace SmartPOS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register application services here
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));


        // Example: services.AddScoped<IMyService, MyService>();
        return services;
    }

}
