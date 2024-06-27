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

    public async Task<ProductDto> GetProductByIdAsync(int productId)
    {
        var product = await GetProductByIdWithCheckAsync(productId);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductPreViewDto> GetProductPreViewAsync(int productId)
    {
        var product = await GetProductByIdWithCheckAsync(productId);
        return _mapper.Map<ProductPreViewDto>(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<IEnumerable<ProductPreViewDto>> GetProductPreViewsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductPreViewDto>>(products);
    }

    public async Task CreateProductAsync(ProductRequestDto productRequestDto)
    {
        var product = _mapper.Map<Product>(productRequestDto);

        try
        {
            await _productRepository.AddAsync(product);
        }
        catch (Exception ex)
        {
            throw new ProductOperationException("Failed to create the product.", ex);
        }
    }

    public async Task UpdateProductAsync(int productId, ProductRequestDto productRequestDto)
    {
        var product = await GetProductByIdWithCheckAsync(productId);

        var updatedProduct = _mapper.Map<Product>(productRequestDto);
        updatedProduct.ProductId = product.ProductId;

        try
        {
            await _productRepository.UpdateAsync(updatedProduct);
        }
        catch (Exception ex)
        {
            throw new ProductOperationException("Failed to update the product.", ex);
        }
    }

    public async Task UpdateProductInfolyAsync(int productId, ProductInfoDto newProductInfoDto)
    {
        var product = await GetProductByIdWithCheckAsync(productId);

        var updatedProduct = _mapper.Map<Product>(newProductInfoDto);
        updatedProduct.ProductId = product.ProductId;

        try
        {
            await _productRepository.UpdateAsync(updatedProduct);
        }
        catch (Exception ex)
        {
            throw new ProductOperationException("Failed to update the product information", ex);
        }
    }

    public async Task DeleteProductAsync(int productId)
    {
        var product = await GetProductByIdWithCheckAsync(productId);

        try
        {
            await _productRepository.DeleteAsync(product);
        }
        catch (Exception ex)
        {
            throw new ProductOperationException("Failed to delete the product.", ex);
        }
    }

    private async Task<Product> GetProductByIdWithCheckAsync(int productId)
    {
        var product = await _productRepository.GetByPredicateAsync(p => p.ProductId == productId);
        if (product == null)
        {
            throw new ProductNotFoundException(productId);
        }
        return product;
    }
}
