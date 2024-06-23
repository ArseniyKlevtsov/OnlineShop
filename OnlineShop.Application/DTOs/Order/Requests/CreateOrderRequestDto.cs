namespace OnlineShop.Application.DTOs.Order.Requests;

public class CreateOrderRequestDto
{
    public DateTime OrderDate { get; set; }
    public string UserId { get; set; }
    public ICollection<OrderItemRequestDto> OrderItems { get; set; }
}
