using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.ProductDTOs.Requests;
using OnlineShop.Application.DTOs.ProductDTOs.Responses;
using OnlineShop.Application.Interfaces;

namespace OnlineShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult<ProductDto>> GetProductById(int id, CancellationToken cancellationToken)
    {
        var product = await _productService.GetProductByIdAsync(id, cancellationToken);
        return Ok(product);
    }

    [HttpGet("preview/{id}")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult<ProductPreViewDto>> GetProductPreView(int id, CancellationToken cancellationToken)
    {
        var productPreView = await _productService.GetProductPreViewAsync(id, cancellationToken);
        return Ok(productPreView);
    }

    [HttpGet]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts(CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllProductsAsync(cancellationToken);
        return Ok(products);
    }

    [HttpGet("preview")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult<IEnumerable<ProductPreViewDto>>> GetProductsPreviews(CancellationToken cancellationToken)
    {
        var productsPreviews = await _productService.GetProductPreViewsAsync(cancellationToken);
        return Ok(productsPreviews);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateProduct(ProductRequestDto productRequestDto, CancellationToken cancellationToken)
    {
        await _productService.CreateProductAsync(productRequestDto, cancellationToken);
        return NoContent();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateProduct(int id, ProductRequestDto productRequestDto, CancellationToken cancellationToken)
    {
        await _productService.UpdateProductAsync(id, productRequestDto, cancellationToken);
        return NoContent();
    }

    [HttpPut("info/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateProductInfo(int id, ProductInfoDto newProductInfoDto, CancellationToken cancellationToken)
    {
        await _productService.UpdateProductInfolyAsync(id, newProductInfoDto, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
    {
        await _productService.DeleteProductAsync(id, cancellationToken);
        return NoContent();
    }
}