using AutoMapper;
using OnlineShop.Application.DTOs.OrderDTOs.Requests;
using OnlineShop.Application.DTOs.OrderDTOs.Responses;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(int orderId)
        {
            return await GetOrderByIdAsync(orderId, CancellationToken.None);
        }

        public async Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync()
        {
            return await GetAllOrdersAsync(CancellationToken.None);
        }

        public async Task<IEnumerable<OrderResponseDto>> GetOrdersByUserIdAsync(string userId)
        {
            return await GetOrdersByUserIdAsync(userId, CancellationToken.None);
        }

        public async Task<GetOrderWithDetailsResponseDto> GetOrderWithDetailsAsync(int orderId)
        {
            return await GetOrderWithDetailsAsync(orderId, CancellationToken.None);
        }

        public async Task<OrderResponseDto> CreateOrderAsync(OrderRequestDto orderDto)
        {
            return await CreateOrderAsync(orderDto, CancellationToken.None);
        }

        public async Task UpdateOrderAsync(int orderId, OrderRequestDto order)
        {
            await UpdateOrderAsync(orderId, order, CancellationToken.None);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await DeleteOrderAsync(orderId, CancellationToken.None);
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(int orderId, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderWithDetailsAsync(orderId, cancellationToken);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID {orderId} not found.");
            }
            return _mapper.Map<OrderResponseDto>(order);
        }

        public async Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync(CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
        }

        public async Task<IEnumerable<OrderResponseDto>> GetOrdersByUserIdAsync(string userId, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId, cancellationToken);
            return _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
        }

        public async Task<GetOrderWithDetailsResponseDto> GetOrderWithDetailsAsync(int orderId, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderWithDetailsAsync(orderId, cancellationToken);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID {orderId} not found.");
            }
            return _mapper.Map<GetOrderWithDetailsResponseDto>(order);
        }

        public async Task<OrderResponseDto> CreateOrderAsync(OrderRequestDto orderDto, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.AddAsync(order, cancellationToken);
            return _mapper.Map<OrderResponseDto>(order);
        }

        public async Task UpdateOrderAsync(int orderId, OrderRequestDto orderDto, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderWithDetailsAsync(orderId, cancellationToken);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID {orderId} not found.");
            }

            _mapper.Map(orderDto, order);
            await _orderRepository.UpdateAsync(order, cancellationToken);
        }

        public async Task DeleteOrderAsync(int orderId, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderWithDetailsAsync(orderId, cancellationToken);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID {orderId} not found.");
            }

            await _orderRepository.DeleteAsync(order, cancellationToken);
        }
    }
}
