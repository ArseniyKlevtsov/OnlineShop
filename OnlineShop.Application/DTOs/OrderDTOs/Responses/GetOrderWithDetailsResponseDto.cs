using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.DTOs.OrderDTOs.Responses;

public class GetOrderWithDetailsResponseDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}
