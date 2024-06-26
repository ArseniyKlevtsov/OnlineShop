using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.DTOs.CategoryDTOs.Responses;

public class CategoryResponseDto
{
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public ICollection<Product>? Products { get; set; }
}
