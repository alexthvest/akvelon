using OnlineShop.Application.Abstractions;
using OnlineShop.Application.Dto;
using OnlineShop.Application.Requests;
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

    public IReadOnlyCollection<ProductDto> GetProducts()
    {
        return _productRepository.GetProducts()
                .Select(product => new ProductDto(product))
                .ToArray();
    }

    public async Task<ProductDto> InsetProductAsync(CreateProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
        };

        var entity = await _productRepository.InsertProductAsync(product);

        return new ProductDto(entity);
    }
}
