using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dto;
using WebAPI.MockFactory.Tests.Data;
using Xunit;

namespace OnlineShop.Web.Tests.Controllers;

public class ProductsControllerTests : TestBase
{
    [Fact]
    public void TestCase()
    {
        // Arrange
        var databaseInitializer = TestDataFactory.CreateDatabaseInitializer();

        databaseInitializer.InitializeDatabase((logger, databaseContext) =>
        {
            databaseContext.AddRange(TestProducts.AllProducts);
            databaseContext.SaveChanges();
        });

        var controllerFactory = TestDataFactory.CreateControllerFactory();
        var productsController = controllerFactory.CreateProductsController();

        // Act
        var result = productsController.GetProducts();

        // Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
        var listOfProducts = Assert.IsType<ProductDto[]>(okObjectResult.Value);

        Assert.Equal(TestProducts.AllProducts.Count, listOfProducts.Length);
    }
}
