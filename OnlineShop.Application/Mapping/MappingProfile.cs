using AutoMapper;
using OnlineShop.Domain.Entities;
using OnlineShop.Application.DTOs.OrderDTOs.Requests;
using OnlineShop.Application.DTOs.OrderDTOs.Responses;

namespace OnlineShop.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderResponseDto>();
            CreateMap<OrderRequestDto, Order>();
        }
    }
}
