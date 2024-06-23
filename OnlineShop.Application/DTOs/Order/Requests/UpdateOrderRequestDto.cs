namespace OnlineShop.Application.DTOs.Order.Requests;

public class UpdateOrderRequestDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string UserId { get; set; }
    public ICollection<OrderItemRequestDto> OrderItems { get; set; }
}
