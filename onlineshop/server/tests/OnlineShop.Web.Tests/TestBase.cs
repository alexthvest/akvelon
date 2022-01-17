using System;
using WebAPI.MockFactory.Tests.Factory;

namespace OnlineShop.Web.Tests;

public abstract class TestBase : IDisposable
{
    protected TestBase()
    {
        TestDataFactory = new TestDataFactory();
    }

    protected ITestDataFactory TestDataFactory { get; }

    public void Dispose()
    {
        TestDataFactory.Dispose();
    }
}
