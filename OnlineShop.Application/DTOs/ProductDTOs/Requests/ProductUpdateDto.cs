namespace OnlineShop.Application.DTOs.ProductDTOs.Requests;

public class ProductUpdateDto
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public int CategoryId { get; set; }
}
