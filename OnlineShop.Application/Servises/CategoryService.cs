using AutoMapper;
using OnlineShop.Application.DTOs.CategoryDTOs.Requests;
using OnlineShop.Application.DTOs.CategoryDTOs.Responses;
using OnlineShop.Application.Exceptions;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryResponseDto> GetCategoryByIdAsync(int categoryId)
    {
        var category = await _categoryRepository.GetByIdWithRelatedProductsAsync(categoryId);
        if (category == null)
        {
            throw new NotFoundException($"Category with id {categoryId} not found.");
        }
        return _mapper.Map<CategoryResponseDto>(category);
    }

    public async Task<CategoryPreviewResponseDto> GetCategoryPreviewAsync(int categoryId)
    {
        var category = await _categoryRepository.GetByIdWithRelatedProductsAsync(categoryId);
        if (category == null)
        {
            throw new NotFoundException($"Category with id {categoryId} not found.");
        }
        return _mapper.Map<CategoryPreviewResponseDto>(category);
    }

    public async Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
    }

    public async Task<IEnumerable<CategoryPreviewResponseDto>> GetCategoryPreviewsAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryPreviewResponseDto>>(categories);
    }

    public async Task<CategoryResponseDto> CreateCategoryAsync(CategoryRequestDto categoryRequestDto)
    {
        var category = _mapper.Map<Category>(categoryRequestDto);
        await _categoryRepository.AddAsync(category);
        return _mapper.Map<CategoryResponseDto>(category);
    }

    public async Task<CategoryResponseDto> UpdateCategoryAsync(int id, CategoryRequestDto categoryRequestDto)
    {
        var existingCategory = await _categoryRepository.GetByPredicateAsync(c => c.CategoryId == id);
        if (existingCategory == null)
        {
            throw new NotFoundException($"Category with id {id} not found.");
        }

        _mapper.Map(categoryRequestDto, existingCategory);
        await _categoryRepository.UpdateAsync(existingCategory);
        return _mapper.Map<CategoryResponseDto>(existingCategory);
    }

    public async Task DeleteCategoryAsync(int categoryId)
    {
        var category = await _categoryRepository.GetByPredicateAsync(c => c.CategoryId == categoryId);
        if (category == null)
        {
            throw new NotFoundException($"Category with id {categoryId} not found.");
        }

        await _categoryRepository.DeleteByIdAsync(categoryId);
    }
}