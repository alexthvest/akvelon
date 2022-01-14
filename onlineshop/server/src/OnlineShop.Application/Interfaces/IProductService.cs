using OnlineShop.Application.Dto.Request;
using OnlineShop.Application.Dto.Response;

namespace OnlineShop.Application.Interfaces;

public interface IProductService
{
    IReadOnlyCollection<ProductDto> GetProducts();

    ProductDto InsetProduct(ProductCreateRequestDto product);
}
