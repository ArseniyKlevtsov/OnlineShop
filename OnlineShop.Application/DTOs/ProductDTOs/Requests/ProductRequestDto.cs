namespace OnlineShop.Application.DTOs.ProductDTOs.Requests;

public class ProductRequestDto
{
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public int CategoryId { get; set; }

}
