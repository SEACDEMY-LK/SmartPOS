using SmartPOS.Domain.Products;

namespace SmartPOS.Application.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(int id, CancellationToken ct);
    
    Task AddProductAsync(Product product);
    
    Task UpdateProductAsync(Product product);
    
    Task DeleteProductAsync(Product product);

    Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken ct);

    Task SaveChanges(CancellationToken ct);
}
