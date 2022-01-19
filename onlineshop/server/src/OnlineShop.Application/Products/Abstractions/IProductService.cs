using OnlineShop.Application.Products.Common;

namespace OnlineShop.Application.Products.Abstractions;

public interface IProductService
{
    IReadOnlyCollection<ProductDto> GetProducts();

    ProductDto? GetProductById(Guid id);

    Task<ProductDto> AddProductAsync(ProductDetailsDto productDetails, CancellationToken cancellationToken);

    Task<ProductDto?> UpdateProductAsync(Guid id, ProductDetailsDto productDetails, CancellationToken cancellationToken);

    Task<bool> RemoveProductAsync(Guid id, CancellationToken cancellationToken);
}
