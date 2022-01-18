using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Abstractions;
using OnlineShop.Application.Dto;
using OnlineShop.Application.Requests;

namespace OnlineShop.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductService _productService;

    public ProductsController(ILogger<ProductsController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<IReadOnlyCollection<ProductDto>> GetProducts()
    {
        var products = _productService.GetProducts();

        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> InsertProductAsync([FromBody] CreateProductRequest request)
    {
        var response = await _productService.InsetProductAsync(request);

        return Ok(response);
    }
}
