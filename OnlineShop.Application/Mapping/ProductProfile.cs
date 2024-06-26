using AutoMapper;
using OnlineShop.Application.DTOs.ProductDTOs.Requests;
using OnlineShop.Application.DTOs.ProductDTOs.Responses;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductRequestDto>().ReverseMap();

        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductInfoDto>().ReverseMap();
        CreateMap<Product, ProductPreViewDto>().ReverseMap();
    }
}