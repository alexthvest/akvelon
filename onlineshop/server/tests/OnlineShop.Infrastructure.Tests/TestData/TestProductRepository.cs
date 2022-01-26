using System;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Data.Common;

namespace OnlineShop.Infrastructure.Tests.TestData;

public class TestProductRepository : RepositoryBase<Product, Guid>
{
    public TestProductRepository(DbContext context)
        : base(context)
    {
    }
}
