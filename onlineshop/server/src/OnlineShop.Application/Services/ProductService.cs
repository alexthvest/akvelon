using OnlineShop.Application.Abstractions;
using OnlineShop.Application.Requests;
using OnlineShop.Application.Responses;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;

namespace OnlineShop.Application.Services;

internal class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IReadOnlyCollection<ProductResponse> GetProducts()
    {
        return _productRepository.GetProducts()
                .Select(product => new ProductResponse(product))
                .ToArray();
    }

    public async Task<ProductResponse> InsetProductAsync(CreateProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
        };

        var entity = await _productRepository.InsertProductAsync(product);

        return new ProductResponse(entity);
    }
}
