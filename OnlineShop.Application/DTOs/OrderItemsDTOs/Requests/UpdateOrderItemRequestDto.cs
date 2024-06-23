namespace OnlineShop.Application.DTOs.OrderItemsDTOs.Requests;
public class UpdateOrderItemRequestDto
{
    public int OrderItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}