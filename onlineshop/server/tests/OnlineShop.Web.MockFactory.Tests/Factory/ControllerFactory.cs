using Microsoft.Extensions.Logging;
using OnlineShop.Web.Controllers;
using WebAPI.MockFactory.Tests.Factory.Interfaces;

namespace WebAPI.MockFactory.Tests.Factory;

public class ControllerFactory : IControllerFactory
{
    private readonly IServiceFactory _serviceFactory;
    private readonly ILoggerFactory _loggerFactory;

    public ControllerFactory(IServiceFactory serviceFactory, ILoggerFactory loggerFactory)
    {
        _serviceFactory = serviceFactory;
        _loggerFactory = loggerFactory;
    }

    public ProductsController CreateProductsController()
    {
        return new ProductsController(_loggerFactory.CreateLogger<ProductsController>(), _serviceFactory.CreateProductService());
    }
}
