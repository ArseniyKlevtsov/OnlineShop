using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.OrderDTOs.Requests;
using OnlineShop.Application.DTOs.OrderDTOs.Responses;
using OnlineShop.Application.Interfaces;
using AutoMapper;

namespace OnlineShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponseDto>> GetOrderByIdAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderByIdAsync(id, cancellationToken);
            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponseDto>>> GetAllOrdersAsync(CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetAllOrdersAsync(cancellationToken);
            return Ok(orders);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDto>>> GetOrdersByUserIdAsync([FromRoute] string userId, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(userId, cancellationToken);
            return Ok(orders);
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<GetOrderWithDetailsResponseDto>> GetOrderWithDetailsAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderWithDetailsAsync(id, cancellationToken);
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponseDto>> CreateOrderAsync([FromBody] OrderRequestDto orderRequestDto, CancellationToken cancellationToken)
        {
            await _orderService.CreateOrderAsync(orderRequestDto, cancellationToken);

            var createdOrderResponse = _mapper.Map<OrderResponseDto>(orderRequestDto);

            var createdOrder = await _orderService.GetOrderWithDetailsAsync(createdOrderResponse.OrderId, cancellationToken);
            createdOrderResponse.OrderId = createdOrder.OrderId;

            return CreatedAtAction(nameof(GetOrderByIdAsync), new { id = createdOrderResponse.OrderId }, createdOrderResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderAsync([FromRoute] int id, [FromBody] OrderRequestDto orderRequestDto, CancellationToken cancellationToken)
        {
            await _orderService.UpdateOrderAsync(id, orderRequestDto, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            await _orderService.DeleteOrderAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
