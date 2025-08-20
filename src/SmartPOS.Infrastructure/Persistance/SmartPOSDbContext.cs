using Microsoft.EntityFrameworkCore;
using SmartPOS.Domain.Products;

namespace SmartPOS.Infrastructure.Persistance;

public class SmartPOSDbContext(DbContextOptions<SmartPOSDbContext> options) : DbContext(options)
{
    // Define your DbSets here, e.g.:
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmartPOSDbContext).Assembly);
    }
}
