using AutoMapper;
using OnlineShop.Application.DTOs.CategoryDTOs.Requests;
using OnlineShop.Application.DTOs.CategoryDTOs.Responses;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mapping;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryResponseDto>();
        CreateMap<Category, CategoryPreviewResponseDto>();
        CreateMap<Category, CategoryInfoResponseDto>();
        CreateMap<CategoryRequestDto, Category>();
    }
}