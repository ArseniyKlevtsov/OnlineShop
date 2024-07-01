using OnlineShop.Application.DTOs.OrderItemsDTOs.Requests;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Responses;

namespace OnlineShop.Application.Interfaces
{
    public interface IOrderItemService
    {
        Task<OrderItemDtoResponse> GetOrderItemAsync(int orderItemId, CancellationToken cancellationToken);
        Task<IEnumerable<OrderItemDtoResponse>> GetAllOrderItemsAsync(CancellationToken cancellationToken);
        Task<OrderItemDtoResponse> CreateOrderItemAsync(CreateOrderItemRequestDto createOrderItemRequestDto, CancellationToken cancellationToken);
        Task<OrderItemDtoResponse> UpdateOrderItemAsync(int id, UpdateOrderItemRequestDto updateOrderItemRequestDto, CancellationToken cancellationToken);
        Task DeleteOrderItemAsync(int orderItemId, CancellationToken cancellationToken);
    }
}
