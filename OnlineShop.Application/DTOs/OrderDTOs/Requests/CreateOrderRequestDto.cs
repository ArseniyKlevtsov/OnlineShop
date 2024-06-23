using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.DTOs.OrderDTOs.Requests;

public class CreateOrderRequestDto
{
    public DateTime OrderDate { get; set; }
    public string UserId { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}
