using AutoMapper;
using OnlineShop.Application.DTOs.ProductDTOs.Requests;
using OnlineShop.Application.DTOs.ProductDTOs.Responses;
using OnlineShop.Application.Exceptions.ProductExceptions;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.Servises;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> GetProductByIdAsync(int productId, CancellationToken cancellationToken)
    {
        var product = await GetProductByIdWithCheckAsync(productId, cancellationToken);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductPreViewDto> GetProductPreViewAsync(int productId, CancellationToken cancellationToken)
    {
        var product = await GetProductByIdWithCheckAsync(productId, cancellationToken);
        return _mapper.Map<ProductPreViewDto>(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<IEnumerable<ProductPreViewDto>> GetProductPreViewsAsync(CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ProductPreViewDto>>(products);
    }

    public async Task CreateProductAsync(ProductRequestDto productRequestDto, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(productRequestDto);

        try
        {
            await _productRepository.AddAsync(product, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new ProductOperationException("Failed to create the product.", ex);
        }
    }

    public async Task UpdateProductAsync(int productId, ProductRequestDto productRequestDto, CancellationToken cancellationToken)
    {
        var product = await GetProductByIdWithCheckAsync(productId, cancellationToken);

        var updatedProduct = _mapper.Map<Product>(productRequestDto);
        updatedProduct.ProductId = product.ProductId;

        try
        {
            await _productRepository.UpdateAsync(updatedProduct, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new ProductOperationException("Failed to update the product.", ex);
        }
    }

    public async Task UpdateProductInfolyAsync(int productId, ProductInfoDto newProductInfoDto, CancellationToken cancellationToken)
    {
        var product = await GetProductByIdWithCheckAsync(productId, cancellationToken);

        var updatedProduct = _mapper.Map<Product>(newProductInfoDto);
        updatedProduct.ProductId = product.ProductId;

        try
        {
            await _productRepository.UpdateAsync(updatedProduct, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new ProductOperationException("Failed to update the product information", ex);
        }
    }

    public async Task DeleteProductAsync(int productId, CancellationToken cancellationToken)
    {
        var product = await GetProductByIdWithCheckAsync(productId, cancellationToken);

        try
        {
            await _productRepository.DeleteAsync(product, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new ProductOperationException("Failed to delete the product.", ex);
        }
    }

    private async Task<Product> GetProductByIdWithCheckAsync(int productId, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByPredicateAsync(p => p.ProductId == productId, cancellationToken);
        return product ?? throw new ProductNotFoundException($"Product not found.", productId);
    }
}
