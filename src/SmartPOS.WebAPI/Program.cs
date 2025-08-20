using Microsoft.EntityFrameworkCore;
using Polly;
using SmartPOS.Application;
using SmartPOS.Domain.Products;
using SmartPOS.Infrastructure;
using SmartPOS.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();


if (!builder.Environment.IsEnvironment("Testing"))
{
    builder.Services.AddInfrastructure(configuration);
}


var app = builder.Build();

var retryPolicy = Policy
    .Handle<Exception>()
    .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(2));

retryPolicy.Execute(() =>
{

    // Ensure the database is created
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<SmartPOSDbContext>();

    try
    {
        if (!app.Environment.IsEnvironment("Testing"))
        {
            dbContext.Database.Migrate();
        }
        else
        {
            dbContext.Database.EnsureDeleted();
        }

        if (!dbContext.Products.Any())
        {
            // Seed the database with initial data if needed
            dbContext.Products.AddRange(
                new Product("Product1", "Pencil", 10.0m),
                new Product("Product2", "Pen", 5.0m),
                new Product("Product3", "Eraser", 1.0m)
            );

            dbContext.SaveChanges();

        }

    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while ensuring the database is created or migrated.");
        throw;
    }
});    


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.Run();

// For Integration Tests
public partial class Program {}

