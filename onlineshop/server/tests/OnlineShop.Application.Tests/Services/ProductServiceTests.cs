using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Moq;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.Products.Abstractions;
using OnlineShop.Application.Products.Common;
using OnlineShop.Application.Products.Services;
using OnlineShop.Application.Tests.TestData;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using OnlineShop.Tests.Common.Data;
using Xunit;

namespace OnlineShop.Application.Tests.Services;

public class ProductServiceTests
{
    private readonly Mock<IValidator<ProductDetailsDto>> _productDetailsDtoValidatorMock;
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly IProductService _productService;

    public ProductServiceTests()
    {
        var logger = Mock.Of<ILogger<ProductService>>();

        var mapper = new MapperConfiguration(x => x.AddProfile<MappingProfile>())
            .CreateMapper();

        _productDetailsDtoValidatorMock = new Mock<IValidator<ProductDetailsDto>>();
        _productRepositoryMock = new Mock<IProductRepository>();

        _productService = new ProductService(
            logger,
            mapper, 
            _productRepositoryMock.Object,
            _productDetailsDtoValidatorMock.Object);
    }

    [Fact]
    public void ShouldReturnEmptyProductArray_WhenNoProductsExist_Or_MarkedAsDeleted()
    {
        // Arrange
        _productRepositoryMock.Setup(x => x.Find(product => !product.Deleted))
            .Returns(Enumerable.Empty<Product>().AsQueryable());

        // Act
        var productDtos = _productService.GetProducts();

        // Assert
        Assert.IsType<ProductDto[]>(productDtos);
        Assert.Empty(productDtos);
    }

    [Fact]
    public void ShouldReturnProductArray_WhenProductsExist_And_NotMarkedAsDeleted()
    {
        // Arrange
        var products = ProductTestData.Products;

        _productRepositoryMock.Setup(x => x.Find(p => !p.Deleted))
            .Returns(products.AsQueryable());

        // Act
        var productDtos = _productService.GetProducts();

        // Assert
        Assert.IsType<ProductDto[]>(productDtos);
        Assert.Equal(products.Length, productDtos.Count);
    }

    [Fact]
    public void ShouldReturnProductById_WhenProductExists_And_NotMarkedAsDeleted()
    {
        // Arrange
        var product = ProductTestData.ProductA;
        var productId = product.Id;

        _productRepositoryMock.Setup(x => x.FindOne(p => p.Id == productId && !p.Deleted))
            .Returns(product);

        // Act
        var productDto = _productService.GetProductById(productId);

        // Assert
        Assert.IsType<ProductDto>(productDto);
        Assert.NotNull(productDto);
        Assert.Equal(productId, productDto!.Id);
    }

    [Fact]
    public void ShouldNotReturnProductById_WhenProductNotExists_Or_MarkedAsDeleted()
    {
        // Arrange
        var productId = ProductTestData.ProductC.Id;

        _productRepositoryMock.Setup(x => x.FindOne(p => p.Id == productId && !p.Deleted))
            .Returns(() => null);

        // Act
        var productDto = _productService.GetProductById(productId);

        // Assert
        Assert.Null(productDto);
    }

    [Fact]
    public async Task ShouldReturnSameProductDto_AsProvidedProductDetailsDto()
    {
        // Arrange
        var productDetails = ProductDetailsTestData.ValidProductDetails;

        // Act
        var productDto = await _productService.AddProductAsync(productDetails, CancellationToken.None);

        // Assert
        Assert.Equal(productDetails.Name, productDto.Name);
        Assert.Equal(productDetails.Description, productDto.Description);
        Assert.Equal(productDetails.Price, productDto.Price);
    }

    [Fact]
    public async Task ShouldThrowValidationException_OnAddProduct_WhenValidationIsFailed()
    {
        // Arrange
        var productDetails = ProductDetailsTestData.InvalidProductDetails;

        var validationResult = new ValidationResult
        {
            Errors =
            {
                new ValidationFailure("Name", "Message"),
            },
        };

        _productDetailsDtoValidatorMock.Setup(x => x.Validate(productDetails))
            .Returns(validationResult);

        // Act
        Task Action()
        {
            return _productService.AddProductAsync(productDetails, CancellationToken.None);
        }

        // Assert
        await Assert.ThrowsAsync<ValidationException>(Action);

        _productRepositoryMock.Verify(
            x => x.AddAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()), 
            Times.Never);
    }

    [Fact]
    public async Task ShouldUpdateProduct_ByProvidedProductDetailsDto()
    {
        // Arrange
        var product = ProductTestData.ProductA;
        var productId = product.Id;
        var productDetails = ProductDetailsTestData.ValidProductDetails;

        _productRepositoryMock.Setup(x => x.FindOne(p => p.Id == productId && !p.Deleted))
            .Returns(product);

        // Act
        var productDto = await _productService.UpdateProductAsync(productId, productDetails, CancellationToken.None);

        // Assert
        Assert.NotNull(productDto);
        Assert.Equal(productDetails.Name, productDto!.Name);
        Assert.Equal(productDetails.Description, productDto.Description);
        Assert.Equal(productDetails.Price, productDto.Price);
    }

    [Fact]
    public async Task ShouldNotUpdateProduct_WhenProductNotExist_Or_MarkedAsDeleted()
    {
        // Arrange
        var productId = ProductTestData.ProductC.Id;
        var productDetails = ProductDetailsTestData.ValidProductDetails;

        _productRepositoryMock.Setup(x => x.FindOne(p => p.Id == productId && !p.Deleted))
            .Returns(() => null);

        // Act
        var productDto = await _productService.UpdateProductAsync(productId, productDetails, CancellationToken.None);

        // Assert
        Assert.Null(productDto);

        _productRepositoryMock.Verify(
            x => x.UpdateAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }

    [Fact]
    public async Task ShouldThrowValidationException_OnUpdateProduct_WhenValidationIsFailed()
    {
        // Arrange
        var productDetails = ProductDetailsTestData.InvalidProductDetails;

        var validationResult = new ValidationResult
        {
            Errors =
            {
                new ValidationFailure("Name", "Message"),
            },
        };

        _productDetailsDtoValidatorMock.Setup(x => x.Validate(productDetails))
            .Returns(validationResult);

        // Act
        Task Action()
        {
            return _productService.UpdateProductAsync(Guid.NewGuid(), productDetails, CancellationToken.None);
        }

        // Assert
        await Assert.ThrowsAsync<ValidationException>(Action);

        _productRepositoryMock.Verify(
            x => x.UpdateAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }

    [Fact]
    public async Task ShouldMarkProductAsDeleted_WhenProductExists_And_NotMarkedAsDeleted()
    {
        // Arrange
        var product = ProductTestData.ProductC;
        var productId = product.Id;

        _productRepositoryMock.Setup(x => x.FindOne(p => p.Id == productId && !p.Deleted))
            .Returns(product);

        // Act
        var operationResult = await _productService.RemoveProductAsync(productId, CancellationToken.None);

        // Assert
        Assert.True(operationResult);
        Assert.True(product.Deleted);
    }

    [Fact]
    public async Task ShouldNotRemoveProduct_WhenProductNotExists_Or_MarkedAsDeleted()
    {
        // Arrange
        var productId = ProductTestData.ProductC.Id;

        _productRepositoryMock.Setup(x => x.FindOne(p => p.Id == productId && !p.Deleted))
            .Returns(() => null);

        // Act
        var operationResult = await _productService.RemoveProductAsync(productId, CancellationToken.None);

        // Assert
        Assert.False(operationResult);

        _productRepositoryMock.Verify(
            x => x.UpdateAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }
}
