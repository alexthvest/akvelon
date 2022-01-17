using OnlineShop.Infrastructure.Data;

namespace WebAPI.MockFactory.Tests.Factory.Interfaces;

public interface IRepositoryContextFactory : IDisposable
{
    ApplicationDbContext CreateDatabaseContext();
}