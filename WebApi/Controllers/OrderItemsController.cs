using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Requests;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Responses;
using OnlineShop.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet("{orderItemId}")]
        public async Task<ActionResult<OrderItemDtoResponse>> GetOrderItem([FromRoute] int orderItemId, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemService.GetOrderItemAsync(orderItemId, cancellationToken);
            return Ok(orderItem);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemDtoResponse>>> GetAllOrderItems(CancellationToken cancellationToken)
        {
            var orderItems = await _orderItemService.GetAllOrderItemsAsync(cancellationToken);
            return Ok(orderItems);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemDtoResponse>> CreateOrderItem([FromBody] CreateOrderItemRequestDto createOrderItemRequestDto, CancellationToken cancellationToken)
        {
            var createdOrderItem = await _orderItemService.CreateOrderItemAsync(createOrderItemRequestDto, cancellationToken);
            return CreatedAtAction(nameof(GetOrderItem), new { orderItemId = createdOrderItem.OrderItemId }, createdOrderItem);
        }

        [HttpPut("{orderItemId}")]
        public async Task<ActionResult<OrderItemDtoResponse>> UpdateOrderItem([FromRoute] int orderItemId, [FromBody] UpdateOrderItemRequestDto updateOrderItemRequestDto, CancellationToken cancellationToken)
        {
            var updatedOrderItem = await _orderItemService.UpdateOrderItemAsync(orderItemId, updateOrderItemRequestDto, cancellationToken);
            return Ok(updatedOrderItem);
        }

        [HttpDelete("{orderItemId}")]
        public async Task<IActionResult> DeleteOrderItem([FromRoute] int orderItemId, CancellationToken cancellationToken)
        {
            await _orderItemService.DeleteOrderItemAsync(orderItemId, cancellationToken);
            return NoContent();
        }
    }
}
