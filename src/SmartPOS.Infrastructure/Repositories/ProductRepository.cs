using Microsoft.EntityFrameworkCore;
using SmartPOS.Application.Interfaces;
using SmartPOS.Domain.Products;
using SmartPOS.Infrastructure.Persistance;

namespace SmartPOS.Infrastructure.Repositories;

public sealed class ProductRepository(SmartPOSDbContext context) : IProductRepository
{
    public async Task AddProductAsync(Product product)
    {
        await context.Products.AddAsync(product);
    }

    public Task DeleteProductAsync(Product product)
    {
        context.Products.Remove(product);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken ct)
    {
        return await context.Products.AsNoTracking().ToListAsync(ct);
    }

    public async Task<Product?> GetProductByIdAsync(int id, CancellationToken ct)
    {
        return await context.Products.FirstOrDefaultAsync(p=> p.Id == id, ct);
    }

    public async Task SaveChanges(CancellationToken ct)
    {
        await context.SaveChangesAsync(ct);
    }

    public Task UpdateProductAsync(Product product)
    {
        context.Entry(product).State = EntityState.Modified;
        return Task.CompletedTask;
    }
}
