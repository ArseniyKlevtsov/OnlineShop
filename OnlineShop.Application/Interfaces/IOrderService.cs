using OnlineShop.Application.DTOs.OrderDTOs.Requests;
using OnlineShop.Application.DTOs.OrderDTOs.Responses;

namespace OnlineShop.Application.Interfaces;

public interface IOrderService
{
    Task<OrderResponseDto> GetOrderByIdAsync(int orderId);
    Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync();
    Task CreateOrderAsync(CreateOrderRequestDto order);
    Task UpdateOrderAsync(UpdateOrderRequestDto order);
    Task DeleteOrderAsync(int orderId);
    Task<IEnumerable<OrderResponseDto>> GetOrdersByUserIdAsync(string userId);
    Task<GetOrderWithDetailsResponseDto> GetOrderWithDetailsAsync(int orderId);
}
