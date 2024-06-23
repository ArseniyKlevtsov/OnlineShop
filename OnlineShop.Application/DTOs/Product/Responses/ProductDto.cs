﻿using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.DTOs.Product.Responses;

public class ProductDto
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public int CategoryId { get; set; }

    public Category? Category { get; set; }
    public ICollection<OrderItem>? OrderItems { get; set; }
}
