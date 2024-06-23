using OnlineShop.Application.DTOs.Product.Requests;
using OnlineShop.Application.DTOs.Product.Responses;

namespace OnlineShop.Application.Interfaces;

public interface IProductService
{
    Task<ProductDto> GetProductByIdAsync(int productId);
    Task<ProductPreViewDto> GetProductPreViewAsync(int productId);
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<IEnumerable<ProductPreViewDto>> GetProductPreViewsAsync();

    Task<ProductDto> CreateProductAsync(ProductCreateDto productCreateDto);
    Task<ProductDto> UpdateProductAsync(ProductUpdateDto newProductUpdateDto);
    Task<ProductDto> UpdateProductInfolyAsync(int productId, ProductInfoDto newProductInfoDto);
    Task DeleteProductAsync(int productId);
}
