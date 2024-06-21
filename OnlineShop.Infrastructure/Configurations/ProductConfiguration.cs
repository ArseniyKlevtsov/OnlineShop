using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.ProductId);

        builder.Property(p => p.ProductName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.ProductDescription)
               .HasMaxLength(500);

        builder.Property(p => p.ProductPrice)
               .HasPrecision(14, 2);

        builder.HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.OrderItems)
               .WithOne(oi => oi.Product)
               .HasForeignKey(oi => oi.ProductId);
    }
}
