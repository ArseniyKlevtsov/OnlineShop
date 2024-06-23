namespace OnlineShop.Application.DTOs.Order.Responses;

public class GetOrderWithDetailsResponseDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string UserId { get; set; }
    public UserResponseDto User { get; set; }
    public ICollection<OrderItemDtoResponse> OrderItems { get; set; }
}
