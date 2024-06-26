using OnlineShop.Application.DTOs.CategoryDTOs.Requests;
using OnlineShop.Application.DTOs.CategoryDTOs.Responses;

namespace OnlineShop.Application.Interfaces;

public interface ICategoryService
{
    Task<CategoryResponseDto> GetCategoryByIdAsync(int categoryId);
    Task<CategoryPreviewResponseDto> GetCategoryPreviewAsync(int categoryId);
    Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync();
    Task<IEnumerable<CategoryPreviewResponseDto>> GetCategoryPreviewsAsync();

    Task<CategoryResponseDto> CreateCategoryAsync(CategoryRequestDto categoryRequestDto);
    Task<CategoryResponseDto> UpdateCategoryAsync(int id, CategoryRequestDto categoryRequestDto);
    Task DeleteCategoryAsync(int categoryId);
}
