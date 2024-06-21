﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.OrderItemId);

        builder.Property(oi => oi.Quantity)
               .IsRequired();

        builder.Property(oi => oi.UnitPrice)
               .HasPrecision(14, 2);

        builder.HasOne(oi => oi.Product)
               .WithMany(p => p.OrderItems)
               .HasForeignKey(oi => oi.ProductId);

        builder.HasOne(oi => oi.Order)
               .WithMany(o => o.OrderItems)
               .HasForeignKey(oi => oi.OrderId);
    }
}
