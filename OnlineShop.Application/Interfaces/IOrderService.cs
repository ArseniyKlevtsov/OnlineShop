using OnlineShop.Application.DTOs.OrderDTOs.Requests;
using OnlineShop.Application.DTOs.OrderDTOs.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponseDto> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync();
        Task<IEnumerable<OrderResponseDto>> GetOrdersByUserIdAsync(string userId);
        Task<GetOrderWithDetailsResponseDto> GetOrderWithDetailsAsync(int orderId);

        Task CreateOrderAsync(OrderRequestDto order);
        Task UpdateOrderAsync(int orderId, OrderRequestDto order);
        Task DeleteOrderAsync(int orderId);

        Task<OrderResponseDto> GetOrderByIdAsync(int orderId, CancellationToken cancellationToken);
        Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync(CancellationToken cancellationToken);
        Task<IEnumerable<OrderResponseDto>> GetOrdersByUserIdAsync(string userId, CancellationToken cancellationToken);
        Task<GetOrderWithDetailsResponseDto> GetOrderWithDetailsAsync(int orderId, CancellationToken cancellationToken);

        Task CreateOrderAsync(OrderRequestDto order, CancellationToken cancellationToken);
        Task UpdateOrderAsync(int orderId, OrderRequestDto order, CancellationToken cancellationToken);
        Task DeleteOrderAsync(int orderId, CancellationToken cancellationToken);
    }
}
