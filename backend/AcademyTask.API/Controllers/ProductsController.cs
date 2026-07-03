using AcademyTask.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcademyTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    
    public ProductsController(IProductService productService) =>  _productService = productService;

    [HttpPost("postProducts")]
    public async Task<ActionResult> GetAllProducts()
    {
        var result = await _productService.FetchProductsAsync();
        return Ok(result);
    }
}