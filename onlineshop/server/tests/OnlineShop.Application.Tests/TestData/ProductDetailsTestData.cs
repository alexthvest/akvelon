using OnlineShop.Application.Products.Common;

namespace OnlineShop.Application.Tests.TestData;

internal static class ProductDetailsTestData
{
    public static ProductDetailsDto ValidProductDetails => new ()
    {
        Name = "Product",
        Description = "Description",
        Price = 42,
    };

    public static ProductDetailsDto InvalidProductDetails => new ()
    {
        Name = string.Empty,
        Description = string.Empty,
        Price = -1,
    };
}
