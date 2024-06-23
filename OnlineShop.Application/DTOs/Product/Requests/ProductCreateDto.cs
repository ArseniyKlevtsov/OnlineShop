namespace OnlineShop.Application.DTOs.Product.Requests;

public class ProductCreateDto
{
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public int CategoryId { get; set; }

}
