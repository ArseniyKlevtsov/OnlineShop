namespace OnlineShop.Application.DTOs.OrderItemsDTOs.Responses;
public class OrderItemDtoResponse
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string ProductName { get; set; }
}