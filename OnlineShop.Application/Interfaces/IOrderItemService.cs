using OnlineShop.Application.DTOs.OrderItemsDTOs.Requests;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Responses;

namespace OnlineShop.Application.Interfaces;

public interface IOrderItemService
{
    Task<OrderItemDtoResponse> CreateOrderItemAsync(CreateOrderItemRequestDto requestDto);
    Task<OrderItemDtoResponse> UpdateOrderItemAsync(UpdateOrderItemRequestDto requestDto);
    Task<OrderItemDtoResponse> GetOrderItemAsync(int orderItemId);
    Task DeleteOrderItemAsync(int orderItemId);
}