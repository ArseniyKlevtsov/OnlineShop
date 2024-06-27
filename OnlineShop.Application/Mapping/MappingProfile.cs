using AutoMapper;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Requests;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Responses;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrderItemRequestDto, OrderItem>();
            CreateMap<UpdateOrderItemRequestDto, OrderItem>();
            CreateMap<OrderItem, OrderItemDtoResponse>();
        }
    }
}
