﻿using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Data.Repositories;
using WebAPI.MockFactory.Tests.Factory.Interfaces;

namespace WebAPI.MockFactory.Tests.Factory;

public class RepositoryFactory : IRepositoryFactory
{
    private readonly IRepositoryContextFactory _repositoryContextFactory;

    public RepositoryFactory(IRepositoryContextFactory repositoryContextFactory)
    {
        _repositoryContextFactory = repositoryContextFactory;
    }

    public IProductRepository CreateProductRepository()
    {
        return new ProductRepository(_repositoryContextFactory.CreateDatabaseContext());
    }
}