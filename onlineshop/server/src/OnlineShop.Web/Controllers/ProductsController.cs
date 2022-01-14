using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dto.Request;
using OnlineShop.Application.Dto.Response;
using OnlineShop.Application.Interfaces;

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
        return Ok(_productService.GetProducts());
    }

    [HttpPost]
    public ActionResult<ProductDto> InsertProduct([FromBody] ProductCreateRequestDto product)
    {
        return Ok(_productService.InsetProduct(product));
    }
}
