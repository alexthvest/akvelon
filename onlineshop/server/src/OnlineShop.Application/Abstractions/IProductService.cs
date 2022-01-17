using OnlineShop.Application.Requests;
using OnlineShop.Application.Responses;

namespace OnlineShop.Application.Abstractions;

public interface IProductService
{
    IReadOnlyCollection<ProductResponse> GetProducts();

    Task<ProductResponse> InsetProductAsync(CreateProductRequest product);
}
