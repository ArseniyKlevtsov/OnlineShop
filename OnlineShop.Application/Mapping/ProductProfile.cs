using AutoMapper;
using OnlineShop.Application.DTOs.ProductDTOs.Requests;
using OnlineShop.Application.DTOs.ProductDTOs.Responses;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductRequestDto>()
           .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
           .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.ProductDescription))
           .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.ProductPrice))
           .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
           .ReverseMap();

        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.ProductDescription))
            .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.ProductPrice))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
            .ReverseMap();

        CreateMap<Product, ProductInfoDto>()
            .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.ProductDescription))
            .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.ProductPrice))
            .ReverseMap();

        CreateMap<Product, ProductPreViewDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.ProductPrice))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ReverseMap();
    }
}