using AutoMapper;
using OnlineShop.Application.DTOs.CategoryDTOs.Requests;
using OnlineShop.Application.DTOs.CategoryDTOs.Responses;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mapping;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryResponseDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
            .ReverseMap();

        CreateMap<Category, CategoryPreviewResponseDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
            .ReverseMap();

        CreateMap<Category, CategoryInfoResponseDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
            .ReverseMap();

        CreateMap<CategoryRequestDto, Category>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
            .ReverseMap();
    }
}