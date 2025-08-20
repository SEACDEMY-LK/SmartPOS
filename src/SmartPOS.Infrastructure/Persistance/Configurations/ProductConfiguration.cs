using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPOS.Domain.Products;

namespace SmartPOS.Infrastructure.Persistance.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> b)
    {
        b.HasKey(p => p.Id);

        b.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        b.Property(p => p.Description)
            .HasMaxLength(500);

        b.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
    }
}
