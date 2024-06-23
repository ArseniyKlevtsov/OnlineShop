using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.DTOs.ProductDTOs.Responses;

public class ProductPreViewDto
{
    public string? ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public Category? Category { get; set; }
}
