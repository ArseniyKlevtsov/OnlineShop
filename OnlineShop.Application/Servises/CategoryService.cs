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

    public async Task<CategoryResponseDto> GetCategoryByIdAsync(int categoryId, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdWithRelatedProductsAsync(categoryId, cancellationToken);
        if (category == null)
        {
            throw new NotFoundException($"Category with id {categoryId} not found.");
        }
        return _mapper.Map<CategoryResponseDto>(category);
    }

    public async Task<CategoryPreviewResponseDto> GetCategoryPreviewAsync(int categoryId, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdWithRelatedProductsAsync(categoryId, cancellationToken);
        if (category == null)
        {
            throw new NotFoundException($"Category with id {categoryId} not found.");
        }
        return _mapper.Map<CategoryPreviewResponseDto>(category);
    }

    public async Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
    }

    public async Task<IEnumerable<CategoryPreviewResponseDto>> GetCategoryPreviewsAsync(CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<CategoryPreviewResponseDto>>(categories);
    }

    public async Task<CategoryResponseDto> CreateCategoryAsync(CategoryRequestDto categoryRequestDto, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(categoryRequestDto);
        await _categoryRepository.AddAsync(category, cancellationToken);
        return _mapper.Map<CategoryResponseDto>(category);
    }

    public async Task<CategoryResponseDto> UpdateCategoryAsync(int id, CategoryRequestDto categoryRequestDto, CancellationToken cancellationToken)
    {
        var existingCategory = await _categoryRepository.GetByPredicateAsync(c => c.CategoryId == id, cancellationToken);
        if (existingCategory == null)
        {
            throw new NotFoundException($"Category with id {id} not found.");
        }

        _mapper.Map(categoryRequestDto, existingCategory);
        await _categoryRepository.UpdateAsync(existingCategory, cancellationToken);
        return _mapper.Map<CategoryResponseDto>(existingCategory);
    }

    public async Task DeleteCategoryAsync(int categoryId, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByPredicateAsync(c => c.CategoryId == categoryId, cancellationToken);
        if (category == null)
        {
            throw new NotFoundException($"Category with id {categoryId} not found.");
        }

        await _categoryRepository.DeleteByIdAsync(categoryId, cancellationToken);
    }
}