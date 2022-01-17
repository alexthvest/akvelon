using OnlineShop.Domain.Entities;

namespace WebAPI.MockFactory.Tests.Data;

public static class TestProducts
{
    public static Product ProductA => new () { Name = "ProductA", Description = "ProductA Desc", Price = 0 };

    public static Product ProductB => new () { Name = "ProductB", Description = "ProductB Desc", Price = 0 };

    public static Product ProductC => new () { Name = "ProductC", Description = "ProductC Desc", Price = 0 };

    public static List<Product> AllProducts => new () { ProductA, ProductB, ProductC };
}
