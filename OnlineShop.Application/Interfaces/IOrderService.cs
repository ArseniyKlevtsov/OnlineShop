using OnlineShop.Application.DTOs.OrderDTOs.Requests;
using OnlineShop.Application.DTOs.OrderDTOs.Responses;

namespace OnlineShop.Application.Interfaces;

public interface IOrderService
{
    Task<OrderResponseDto> GetOrderByIdAsync(int orderId);
    Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync();
    Task<IEnumerable<OrderResponseDto>> GetOrdersByUserIdAsync(string userId);
    Task<GetOrderWithDetailsResponseDto> GetOrderWithDetailsAsync(int orderId);

    Task CreateOrderAsync(OrderRequestDto order);
    Task UpdateOrderAsync(int orderId, OrderRequestDto order);
    Task DeleteOrderAsync(int orderId);
}
