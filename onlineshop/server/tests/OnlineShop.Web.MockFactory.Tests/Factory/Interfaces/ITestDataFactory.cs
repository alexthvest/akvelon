using OnlineShop.Web.MockFactory.Tests.Utils;
using WebAPI.MockFactory.Tests.Factory.Interfaces;

namespace WebAPI.MockFactory.Tests.Factory;

public interface ITestDataFactory : IDisposable
{
    IControllerFactory CreateControllerFactory();

    IDatabaseInitializer CreateDatabaseInitializer();
}