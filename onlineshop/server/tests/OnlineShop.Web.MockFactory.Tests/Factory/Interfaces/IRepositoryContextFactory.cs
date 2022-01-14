using OnlineShop.Infrastructure.Contexts;

namespace WebAPI.MockFactory.Tests.Factory.Interfaces;

public interface IRepositoryContextFactory : IDisposable
{
    ApplicationDbContext CreateDatabaseContext();
}