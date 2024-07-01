using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.OrderDTOs.Requests;
using OnlineShop.Application.DTOs.OrderDTOs.Responses;
using OnlineShop.Application.Interfaces;

namespace OnlineShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
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
            var createdOrder = await _orderService.CreateOrderAsync(orderRequestDto, cancellationToken);
            return CreatedAtAction(nameof(GetOrderByIdAsync), new { id = createdOrder.OrderId }, createdOrder);
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
