using OnlineShop.Domain.Repositories;

namespace WebAPI.MockFactory.Tests.Factory.Interfaces;

public interface IRepositoryFactory
{
    IProductRepository CreateProductRepository();
}