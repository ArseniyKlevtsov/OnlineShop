using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.CategoryDTOs.Requests;
using OnlineShop.Application.DTOs.CategoryDTOs.Responses;
using OnlineShop.Application.Interfaces;

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
    public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> GetAllCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryResponseDto>> GetCategory(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        return Ok(category);
    }

    [HttpGet("preview/{id}")]
    public async Task<ActionResult<CategoryPreviewResponseDto>> GetCategoryPreview(int id)
    {
        var categoryPreview = await _categoryService.GetCategoryPreviewAsync(id);
        return Ok(categoryPreview);
    }

    [HttpGet("previews")]
    public async Task<ActionResult<IEnumerable<CategoryPreviewResponseDto>>> GetCategoryPreviews()
    {
        var categoryPreviews = await _categoryService.GetCategoryPreviewsAsync();
        return Ok(categoryPreviews);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryResponseDto>> CreateCategory(CategoryRequestDto categoryRequestDto)
    {
        var createdCategory = await _categoryService.CreateCategoryAsync(categoryRequestDto);
        return CreatedAtAction(nameof(GetCategory), new { id = createdCategory.CategoryId }, createdCategory);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryResponseDto>> UpdateCategory(int id, CategoryRequestDto categoryRequestDto)
    {
        var updatedCategory = await _categoryService.UpdateCategoryAsync(id, categoryRequestDto);
        return Ok(updatedCategory);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return NoContent();
    }
}