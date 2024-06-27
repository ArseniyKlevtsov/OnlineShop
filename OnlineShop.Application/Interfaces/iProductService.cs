using OnlineShop.Application.DTOs.ProductDTOs.Requests;
using OnlineShop.Application.DTOs.ProductDTOs.Responses;

namespace OnlineShop.Application.Interfaces;

public interface IProductService
{
    Task<ProductDto> GetProductByIdAsync(int productId);
    Task<ProductPreViewDto> GetProductPreViewAsync(int productId);
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<IEnumerable<ProductPreViewDto>> GetProductPreViewsAsync();

    Task CreateProductAsync(ProductRequestDto productRequestDto);
    Task UpdateProductAsync(int productId, ProductRequestDto productRequestDto);
    Task UpdateProductInfolyAsync(int productId, ProductInfoDto newProductInfoDto);
    Task DeleteProductAsync(int productId);
}
