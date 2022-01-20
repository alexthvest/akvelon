using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Data.Common;
using OnlineShop.Infrastructure.Tests.Extensions;
using OnlineShop.Infrastructure.Tests.TestData;
using OnlineShop.Tests.Common.Data;
using Xunit;

namespace OnlineShop.Infrastructure.Tests.Repositories;

public class RepositoryBaseTests
{
    private readonly Mock<DbContext> _dbContexMock;
    private readonly Mock<DbSet<Product>> _dbSetMock;
    private readonly RepositoryBase<Product, Guid> _repository;

    public RepositoryBaseTests()
    {
        _dbContexMock = new Mock<DbContext>();
        _dbSetMock = new Mock<DbSet<Product>>();
        _repository = new TestProductRepository(_dbContexMock.Object);
    }

    [Fact]
    public void ShouldReturn_Products()
    {
        // Arrange
        var data = ProductTestData.Products.AsQueryable();

        _dbSetMock.SetupSource(data);

        _dbContexMock.Setup(x => x.Set<Product>())
            .Returns(_dbSetMock.Object);

        // Act
        var products = _repository.Find()
            .ToArray();

        // Assert
        Assert.NotEmpty(products);
        Assert.Equal(ProductTestData.Products.Length, products.Length);
    }

    [Fact]
    public void ShouldReturnAllProduct_ByPredicateIfExists()
    {
        // Arrange
        var data = ProductTestData.Products.AsQueryable();
        var product = ProductTestData.ProductA;

        _dbSetMock.SetupSource(data);

        _dbContexMock.Setup(x => x.Set<Product>())
            .Returns(_dbSetMock.Object);

        // Act
        var products = _repository.Find(x => x.Id == product.Id)
            .ToArray();

        // Assert
        Assert.Single(products);
        Assert.Equal(product.Id, products[0].Id);
    }

    [Fact]
    public void ShouldReturnEmptyCollection_ByPredicateIfNotFound()
    {
        // Arrange
        var data = Enumerable.Empty<Product>().AsQueryable();
        var product = ProductTestData.ProductA;

        _dbSetMock.SetupSource(data);

        _dbContexMock.Setup(x => x.Set<Product>())
            .Returns(_dbSetMock.Object);

        // Act
        var products = _repository.Find(x => x.Id == product.Id)
            .ToArray();

        // Assert
        Assert.Empty(products);
    }

    [Fact]
    public void ShouldReturnOneEntity_ByPredicateIfExists()
    {
        // Arrange
        var data = ProductTestData.Products.AsQueryable();
        var product = ProductTestData.ProductA;

        _dbSetMock.SetupSource(data);

        _dbContexMock.Setup(x => x.Set<Product>())
            .Returns(_dbSetMock.Object);

        // Act
        var entity = _repository.FindOne(x => x.Id == product.Id);

        // Assert
        Assert.NotNull(entity);
        Assert.Equal(product.Id, entity!.Id);
    }

    [Fact]
    public async Task ShouldAddEntity_And_SaveChanges()
    {
        // Arrange
        var data = Enumerable.Empty<Product>().AsQueryable();
        var product = ProductTestData.ProductA;

        _dbSetMock.SetupSource(data);

        _dbContexMock.Setup(x => x.Set<Product>())
            .Returns(_dbSetMock.Object);

        // Act
        var entity = await _repository.AddAsync(product);

        // Assert
        Assert.NotNull(entity);
        Assert.Equal(product.Name, entity.Name);

        _dbContexMock.Verify(x => x.AddAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()), Times.Once);
        _dbContexMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task ShouldSetEntityState_ToModified_And_SaveChanges()
    {
        // Arrange
        var data = ProductTestData.Products.AsQueryable();
        var product = ProductTestData.ProductA;

        _dbSetMock.SetupSource(data);

        _dbContexMock.Setup(x => x.Set<Product>())
            .Returns(_dbSetMock.Object);

        // Act
        var entity = await _repository.UpdateAsync(product);

        // Assert
        _dbContexMock.Verify(x => x.Update(product), Times.Once);
        _dbContexMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}