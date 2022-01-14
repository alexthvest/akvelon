using OnlineShop.Application.Dto.Request;
using OnlineShop.Application.Dto.Response;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Repositories;

namespace OnlineShop.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IReadOnlyCollection<ProductDto> GetProducts()
    {
        return _productRepository.GetProducts()
                .Select(product => new ProductDto(product))
                .ToArray();
    }

    public ProductDto InsetProduct(ProductCreateRequestDto product)
    {
        return new ProductDto(_productRepository.InsertProduct(product.ToModel()));
    }
}
