namespace SmartPOS.Domain.Products;

public class Product 
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Product()
    {
        
    }

    // Constructor with required fields Name, Description, and Price
    public Product(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }


}
