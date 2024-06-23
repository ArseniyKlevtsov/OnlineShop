using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.DTOs.Category.Responses;

public class CategoryResponseDto
{
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public ICollection<Product>? Products { get; set; }
}
