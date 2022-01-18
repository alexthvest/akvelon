using OnlineShop.Application.Dto;
using OnlineShop.Application.Requests;

namespace OnlineShop.Application.Abstractions;

public interface IProductService
{
    IReadOnlyCollection<ProductDto> GetProducts();

    Task<ProductDto> InsetProductAsync(CreateProductRequest product);
}
