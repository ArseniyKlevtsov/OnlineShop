using OnlineShop.Application.DTOs.ProductDTOs.Requests;
using OnlineShop.Application.DTOs.ProductDTOs.Responses;

namespace OnlineShop.Application.Interfaces;

public interface IProductService
{
    Task<ProductDto> GetProductByIdAsync(int productId, CancellationToken cancellationToken);
    Task<ProductPreViewDto> GetProductPreViewAsync(int productId, CancellationToken cancellationToken);
    Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken);
    Task<IEnumerable<ProductPreViewDto>> GetProductPreViewsAsync(CancellationToken cancellationToken);

    Task CreateProductAsync(ProductRequestDto productRequestDto, CancellationToken cancellationToken);
    Task UpdateProductAsync(int productId, ProductRequestDto productRequestDto, CancellationToken cancellationToken);
    Task UpdateProductInfolyAsync(int productId, ProductInfoDto newProductInfoDto, CancellationToken cancellationToken);
    Task DeleteProductAsync(int productId, CancellationToken cancellationToken);
}
