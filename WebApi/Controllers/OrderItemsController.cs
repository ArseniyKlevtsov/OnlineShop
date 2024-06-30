using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Requests;
using OnlineShop.Application.DTOs.OrderItemsDTOs.Responses;
using OnlineShop.Application.Interfaces;

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
        public async Task<ActionResult<OrderItemDtoResponse>> GetOrderItem(int orderItemId)
        {
            try
            {
                var orderItem = await _orderItemService.GetOrderItemAsync(orderItemId);
                return Ok(orderItem);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemDtoResponse>>> GetAllOrderItems()
        {
            var orderItems = await _orderItemService.GetAllOrderItemsAsync();
            return Ok(orderItems);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemDtoResponse>> CreateOrderItem(CreateOrderItemRequestDto createOrderItemRequestDto)
        {
            var createdOrderItem = await _orderItemService.CreateOrderItemAsync(createOrderItemRequestDto);
            return CreatedAtAction(nameof(GetOrderItem), new { orderItemId = createdOrderItem.OrderItemId }, createdOrderItem);
        }

        [HttpPut("{orderItemId}")]
        public async Task<ActionResult<OrderItemDtoResponse>> UpdateOrderItem(int orderItemId, UpdateOrderItemRequestDto updateOrderItemRequestDto)
        {
            try
            {
                var updatedOrderItem = await _orderItemService.UpdateOrderItemAsync(orderItemId, updateOrderItemRequestDto);
                return Ok(updatedOrderItem);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{orderItemId}")]
        public async Task<IActionResult> DeleteOrderItem(int orderItemId)
        {
            try
            {
                await _orderItemService.DeleteOrderItemAsync(orderItemId);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
