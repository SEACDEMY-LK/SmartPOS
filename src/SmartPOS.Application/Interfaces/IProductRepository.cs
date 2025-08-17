using SmartPOS.Domain.Entities;

namespace SmartPOS.Application.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(int id);
    
    Task AddProductAsync(Product product);
    
    Task UpdateProductAsync(Product product);
    
    Task DeleteProductAsync(int id);

    Task<IEnumerable<Product>> GetAllProductsAsync();

    Task SaveChanges();
}
