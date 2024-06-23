namespace OnlineShop.Application.DTOs.Order.Responses;

public class OrderResponseDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string UserId { get; set; }
    public UserResponseDto User { get; set; }
    public ICollection<OrderItemResponseDto> OrderItems { get; set; }
}
