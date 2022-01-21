using OnlineShop.Application.Abstractions;

namespace WebAPI.MockFactory.Tests.Factory.Interfaces;

public interface IServiceFactory
{
    IProductService CreateProductService();
}