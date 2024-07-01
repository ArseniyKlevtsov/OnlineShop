using OnlineShop.Application.DTOs.CategoryDTOs.Requests;
using OnlineShop.Application.DTOs.CategoryDTOs.Responses;

namespace OnlineShop.Application.Interfaces;

public interface ICategoryService
{
    Task<CategoryResponseDto> GetCategoryByIdAsync(int categoryId, CancellationToken cancellationToken);
    Task<CategoryPreviewResponseDto> GetCategoryPreviewAsync(int categoryId, CancellationToken cancellationToken);
    Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync(CancellationToken cancellationToken);
    Task<IEnumerable<CategoryPreviewResponseDto>> GetCategoryPreviewsAsync(CancellationToken cancellationToken);

    Task<CategoryResponseDto> CreateCategoryAsync(CategoryRequestDto categoryRequestDto, CancellationToken cancellationToken);
    Task<CategoryResponseDto> UpdateCategoryAsync(int id, CategoryRequestDto categoryRequestDto, CancellationToken cancellationToken);
    Task DeleteCategoryAsync(int categoryId, CancellationToken cancellationToken);
}
