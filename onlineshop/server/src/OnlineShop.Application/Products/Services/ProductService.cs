using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Products.Abstractions;
using OnlineShop.Application.Products.Common;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;

namespace OnlineShop.Application.Products.Services;

internal class ProductService : IProductService
{
    private readonly ILogger<ProductService> _logger;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IValidator<ProductDetailsDto> _productDetailsValidator;

    public ProductService(
        ILogger<ProductService> logger,
        IMapper mapper,
        IProductRepository productRepository,
        IValidator<ProductDetailsDto> productDetailsValidator)
    {
        _logger = logger;
        _mapper = mapper;
        _productRepository = productRepository;
        _productDetailsValidator = productDetailsValidator;
    }

    public IReadOnlyCollection<ProductDto> GetProducts()
    {
        return _productRepository.Find(product => !product.Deleted)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .ToArray();
    }

    public ProductDto? GetProductById(Guid id)
    {
        var product = _productRepository.FindOne(product => product.Id == id && !product.Deleted);

        var productDto = product is not null
            ? _mapper.Map<Product, ProductDto>(product)
            : null;

        if (productDto is null && _logger.IsEnabled(LogLevel.Warning))
        {
            _logger.LogWarning("Product with id {Id} not found", id);
        }

        return productDto;
    }

    public async Task<ProductDto> AddProductAsync(ProductDetailsDto productDetails, CancellationToken cancellationToken)
    {
        if (_productDetailsValidator.Validate(productDetails) is { IsValid: false, Errors: var errors })
        {
            throw new ValidationException(errors);
        }

        var product = _mapper.Map<ProductDetailsDto, Product>(productDetails);

        await _productRepository.AddAsync(product, cancellationToken);

        return _mapper.Map<Product, ProductDto>(product);
    }

    public async Task<ProductDto?> UpdateProductAsync(Guid id, ProductDetailsDto productDetails, CancellationToken cancellationToken)
    {
        if (_productDetailsValidator.Validate(productDetails) is { IsValid: false, Errors: var errors })
        {
            throw new ValidationException(errors);
        }

        var product = _productRepository.FindOne(product => product.Id == id && !product.Deleted);

        if (product is null)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                _logger.LogWarning("Product with id {Id} not found", id);
            }

            return null;
        }

        product.Name = productDetails.Name;
        product.Description = productDetails.Description;
        product.Price = productDetails.Price;

        await _productRepository.UpdateAsync(product, cancellationToken);

        return _mapper.Map<Product, ProductDto>(product);
    }

    public async Task<bool> RemoveProductAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = _productRepository.FindOne(product => product.Id == id && !product.Deleted);

        if (product is null)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                _logger.LogWarning("Product with id {Id} not found", id);
            }

            return false;
        }

        product.MarkDeleted();
        await _productRepository.UpdateAsync(product, cancellationToken);

        return true;
    }
}
