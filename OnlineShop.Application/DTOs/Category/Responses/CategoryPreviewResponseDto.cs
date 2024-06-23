using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.DTOs.Category.Responses;

public class CategoryPreviewResponseDto
{
    public string? CategoryName { get; set; }
    public ICollection<Product>? Products { get; set; }
}
