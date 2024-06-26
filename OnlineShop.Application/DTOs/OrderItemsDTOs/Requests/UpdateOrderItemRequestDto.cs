namespace OnlineShop.Application.DTOs.OrderItemsDTOs.Requests;
public class UpdateOrderItemRequestDto
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}