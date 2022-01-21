using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Products.Abstractions;
using OnlineShop.Application.Products.Common;
using OnlineShop.Web.Common;

namespace OnlineShop.Web.Controllers;

public class ProductsController : ApiControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyCollection<ProductDto>> GetProducts()
    {
        var products = _productService.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ProductDto> GetProductById(Guid id)
    {
        var product = _productService.GetProductById(id);

        return product is null
            ? NotFound()
            : Ok(product);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<ProductDto>> CreateProduct(ProductDetailsDto productDetails, CancellationToken cancellationToken)
    {
        var product = await _productService.AddProductAsync(productDetails, cancellationToken);
        return CreatedAtAction(nameof(CreateProduct), product);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductDto>> UpdateProduct(Guid id, ProductDetailsDto productDetails, CancellationToken cancellationToken)
    {
        var product = await _productService.UpdateProductAsync(id, productDetails, cancellationToken);

        return product is null
            ? NotFound()
            : Ok(product);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RemoveProduct(Guid id, CancellationToken cancellationToken)
    {
        return await _productService.RemoveProductAsync(id, cancellationToken)
            ? NoContent()
            : NotFound();
    }
}
