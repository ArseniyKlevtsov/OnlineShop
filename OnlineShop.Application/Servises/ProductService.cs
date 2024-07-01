using AutoMapper;
using OnlineShop.Application.DTOs.ProductDTOs.Requests;
using OnlineShop.Application.DTOs.ProductDTOs.Responses;
using OnlineShop.Application.Exceptions;
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
        bool isProdictExist = await IsProductAlreadyExistAsync(product.ProductName!, cancellationToken);
        if (isProdictExist)
        {
            throw new AlreadyExistException($"product with name {product.ProductName} already exist");
        }
        await _productRepository.AddAsync(product, cancellationToken);
    }

    public async Task UpdateProductAsync(int productId, ProductRequestDto productRequestDto, CancellationToken cancellationToken)
    {
        var product = await GetProductByIdWithCheckAsync(productId, cancellationToken);

        var updatedProduct = _mapper.Map<Product>(productRequestDto);

        bool isProdictExist = await IsProductAlreadyExistAsync(updatedProduct.ProductName!, cancellationToken);
        if (isProdictExist)
        {
            throw new AlreadyExistException($"product with name {updatedProduct.ProductName} already exist");
        }

        updatedProduct.ProductId = product.ProductId;
        await _productRepository.UpdateAsync(updatedProduct, cancellationToken);
    }

    public async Task UpdateProductInfolyAsync(int productId, ProductInfoDto newProductInfoDto, CancellationToken cancellationToken)
    {
        var product = await GetProductByIdWithCheckAsync(productId, cancellationToken);

        var updatedProduct = _mapper.Map<Product>(newProductInfoDto);
        updatedProduct.ProductId = product.ProductId;

        await _productRepository.UpdateAsync(updatedProduct, cancellationToken);
    }

    public async Task DeleteProductAsync(int productId, CancellationToken cancellationToken)
    {
        var product = await GetProductByIdWithCheckAsync(productId, cancellationToken);
        await _productRepository.DeleteAsync(product, cancellationToken);
    }

    private async Task<Product> GetProductByIdWithCheckAsync(int productId, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByPredicateAsync(p => p.ProductId == productId, cancellationToken);
        return product ?? throw new NotFoundException($"Product with id:{productId} not found.");
    }

    private async Task<bool> IsProductAlreadyExistAsync(string productName, CancellationToken cancellationToken)
    {
        var existingProduct = await _productRepository.GetByPredicateAsync(p => p.ProductName == productName, cancellationToken);
        return existingProduct != null;
    }
}
