using OnlineShop.Application.DTOs.CategoryDTOs.Responses;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Requests;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Responses;

namespace OnlineShop.Application.Interfaces;

public interface IOrderItemService
{
    Task<OrderItemDtoResponse> GetOrderItemAsync(int orderItemId);
    Task<IEnumerable<OrderItemDtoResponse>> GetAllOrderItemsAsync();

    Task<OrderItemDtoResponse> CreateOrderItemAsync(CreateOrderItemRequestDto createOrderItemRequestDto);
    Task<OrderItemDtoResponse> UpdateOrderItemAsync(int id, UpdateOrderItemRequestDto updateOrderItemRequestDto);
    Task DeleteOrderItemAsync(int orderItemId);
}