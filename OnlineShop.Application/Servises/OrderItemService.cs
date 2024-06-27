using AutoMapper;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Requests;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Responses;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<OrderItemDtoResponse> GetOrderItemAsync(int orderItemId)
        {
            var orderItem = await _orderItemRepository.GetByPredicateAsync(oi => oi.OrderItemId == orderItemId);
            if (orderItem == null)
            {
                throw new KeyNotFoundException($"Order item with ID {orderItemId} not found.");
            }
            return _mapper.Map<OrderItemDtoResponse>(orderItem);
        }

        public async Task<IEnumerable<OrderItemDtoResponse>> GetAllOrderItemsAsync()
        {
            var orderItems = await _orderItemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderItemDtoResponse>>(orderItems);
        }

        public async Task<OrderItemDtoResponse> CreateOrderItemAsync(CreateOrderItemRequestDto createOrderItemRequestDto)
        {
            var orderItem = _mapper.Map<OrderItem>(createOrderItemRequestDto);
            await _orderItemRepository.AddAsync(orderItem);
            return _mapper.Map<OrderItemDtoResponse>(orderItem);
        }

        public async Task<OrderItemDtoResponse> UpdateOrderItemAsync(int id, UpdateOrderItemRequestDto updateOrderItemRequestDto)
        {
            var orderItem = await _orderItemRepository.GetByPredicateAsync(oi => oi.OrderItemId == id);
            if (orderItem == null)
            {
                throw new KeyNotFoundException($"Order item with ID {id} not found.");
            }

            _mapper.Map(updateOrderItemRequestDto, orderItem);
            await _orderItemRepository.UpdateAsync(orderItem);
            return _mapper.Map<OrderItemDtoResponse>(orderItem);
        }

        public async Task DeleteOrderItemAsync(int orderItemId)
        {
            var orderItem = await _orderItemRepository.GetByPredicateAsync(oi => oi.OrderItemId == orderItemId);
            if (orderItem == null)
            {
                throw new KeyNotFoundException($"Order item with ID {orderItemId} not found.");
            }

            await _orderItemRepository.DeleteAsync(orderItem);
        }
    }
}
