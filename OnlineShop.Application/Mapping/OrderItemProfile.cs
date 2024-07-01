using AutoMapper;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Requests;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Responses;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mapping;

public class OrderItemProfile : Profile
{
    public OrderItemProfile() { 
    CreateMap<CreateOrderItemRequestDto, OrderItem>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice));

        CreateMap<UpdateOrderItemRequestDto, OrderItem>()
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice));

        CreateMap<OrderItem, OrderItemDtoResponse>()
            .ForMember(dest => dest.OrderItemId, opt => opt.MapFrom(src => src.OrderItemId))
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));
    }
}
