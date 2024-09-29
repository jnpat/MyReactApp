using Microsoft.AspNetCore.Mvc;
using MyReactApp.Server.Models.DTOs;
using MyReactApp.Server.Models.Parameters;
using MyReactApp.Server.Models;
using MyReactApp.Server.Services;

namespace MyReactApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductGetService _getProductService;

    public ProductController(ProductGetService getproductService)
    {
        _getProductService = getproductService;
    }

    [HttpGet(Name = "GetProduct")]
    public async Task<ActionResult<PagedResult<ProductDto>>> Get([FromQuery] ProductQueryParameters query)
    {
        try
        {
            var result = await _getProductService.GetProductsAsync(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}
