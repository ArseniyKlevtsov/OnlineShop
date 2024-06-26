using OnlineShop.Application.DTOs.ProductDTOs.Requests;
using OnlineShop.Application.DTOs.ProductDTOs.Responses;

namespace OnlineShop.Application.Interfaces;

public interface IProductService
{
    Task<ProductDto> GetProductByIdAsync(int productId);
    Task<ProductPreViewDto> GetProductPreViewAsync(int productId);
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<IEnumerable<ProductPreViewDto>> GetProductPreViewsAsync();

    Task<ProductDto> CreateProductAsync(ProductRequestDto productRequestDto);
    Task<ProductDto> UpdateProductAsync(int productId, ProductRequestDto productRequestDto);
    Task<ProductDto> UpdateProductInfolyAsync(int productId, ProductInfoDto newProductInfoDto);
    Task DeleteProductAsync(int productId);
}
