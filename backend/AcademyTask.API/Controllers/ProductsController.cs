using AcademyTask.Application.DTO;
using AcademyTask.Application.Interfaces;
using AcademyTask.Domain.Entities.Product;
using Microsoft.AspNetCore.Mvc;

namespace AcademyTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    
    public ProductsController(IProductService productService) =>  _productService = productService;

    [HttpPost("postProducts")]
    public async Task<ActionResult> FetchProductsExternal()
    {
        var result = await _productService.FetchProductsExternalAsync();
        var productDtoList = result.Select(product => ToDto(product)).ToList();
        
        return Ok(productDtoList);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllProducts()
    {
        var result = await _productService.GetAllProductsAsync();
        var productDtoList = result.Select(product => ToDto(product)).ToList();
        
        return Ok(productDtoList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetProduct([FromRoute] int id)
    {
        var result = await _productService.GetProductByIdAsync(id);

        if (result == null)
            return NotFound();

        var productDto = ToDto(result);
        
        return Ok(productDto);
    }

    [HttpGet("search")]
    public async Task<ActionResult> GetProductsByName([FromQuery] string name)
    {
        var result = await _productService.GetProductsByNameAsync(name);
        var productDtoList = result.Select(product => ToDto(product)).ToList();
        
        return Ok(productDtoList);
    }

    [HttpGet("filter")]
    public async Task<ActionResult> GetProductsByCategoryAndPrice([FromQuery] List<string> category,
        [FromQuery] decimal upperBound = 0, [FromQuery] decimal lowerBound = 0)
    {
        var result = await _productService.GetProductsByCategoryAndPriceAsync(category, upperBound, lowerBound);
        var productDtoList = result.Select(product => ToDto(product)).ToList();
        
        return Ok(productDtoList);
    }

    private static ProductResponseDto ToDto(Product product)
    {
        return new ProductResponseDto()
        {
            ImageUrl = product.ImageUrl,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description
        };
    }
}