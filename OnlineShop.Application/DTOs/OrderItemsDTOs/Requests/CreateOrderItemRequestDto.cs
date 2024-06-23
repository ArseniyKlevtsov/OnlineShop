namespace OnlineShop.Application.DTOs.OrderItemsDTOs.Requests;
public class CreateOrderItemRequestDto
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
