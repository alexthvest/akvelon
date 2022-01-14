﻿using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Services;
using WebAPI.MockFactory.Tests.Factory.Interfaces;

namespace WebAPI.MockFactory.Tests.Factory;

public class ServiceFactory : IServiceFactory
{
    private readonly IRepositoryFactory _repositoryFactory;

    public ServiceFactory(IRepositoryFactory repositoryFactory)
    {
        _repositoryFactory = repositoryFactory;
    }

    public IProductService CreateProductService()
    {
        return new ProductService(_repositoryFactory.CreateProductRepository());
    }
}
