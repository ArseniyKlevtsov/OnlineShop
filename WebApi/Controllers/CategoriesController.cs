using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.CategoryDTOs.Requests;
using OnlineShop.Application.DTOs.CategoryDTOs.Responses;
using OnlineShop.Application.Interfaces;
using System.Threading;

namespace OnlineShop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> GetAllCategories(CancellationToken cancellationToken)
    {
        var categories = await _categoryService.GetAllCategoriesAsync(cancellationToken);
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryResponseDto>> GetCategory(int id, CancellationToken cancellationToken)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id, cancellationToken);
        return Ok(category);
    }

    [HttpGet("preview/{id}")]
    public async Task<ActionResult<CategoryPreviewResponseDto>> GetCategoryPreview(int id, CancellationToken cancellationToken)
    {
        var categoryPreview = await _categoryService.GetCategoryPreviewAsync(id, cancellationToken);
        return Ok(categoryPreview);
    }

    [HttpGet("previews")]
    public async Task<ActionResult<IEnumerable<CategoryPreviewResponseDto>>> GetCategoryPreviews(CancellationToken cancellationToken)
    {
        var categoryPreviews = await _categoryService.GetCategoryPreviewsAsync(cancellationToken);
        return Ok(categoryPreviews);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryResponseDto>> CreateCategory(CategoryRequestDto categoryRequestDto, CancellationToken cancellationToken)
    {
        var createdCategory = await _categoryService.CreateCategoryAsync(categoryRequestDto, cancellationToken);
        return CreatedAtAction(nameof(GetCategory), new { id = createdCategory.CategoryId }, createdCategory);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryResponseDto>> UpdateCategory(int id, CategoryRequestDto categoryRequestDto, CancellationToken cancellationToken)
    {
        var updatedCategory = await _categoryService.UpdateCategoryAsync(id, categoryRequestDto, cancellationToken);
        return Ok(updatedCategory);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCategory(int id, CancellationToken cancellationToken)
    {
        await _categoryService.DeleteCategoryAsync(id, cancellationToken);
        return NoContent();
    }
}