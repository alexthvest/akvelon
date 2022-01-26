using OnlineShop.Domain.Entities;

namespace OnlineShop.Tests.Common.Data;

public static class ProductTestData
{
    public static Product ProductA => new ()
    {
        Id = Guid.Parse("18fe6d9e-f546-4ce5-8752-49d9a5b6cf1a"),
        Name = "ProductA",
        Description = "ProductA Desc",
        Price = 0,
    };

    public static Product ProductB => new ()
    {
        Id = Guid.Parse("c8bcfe53-b21c-462f-abb4-0776f7cd30fe"),
        Name = "ProductB",
        Description = "ProductB Desc",
        Price = 0,
    };

    public static Product ProductC => new ()
    {
        Id = Guid.Parse("e27307e2-d042-4933-a690-6cb3fdec4627"),
        Name = "ProductC",
        Description = "ProductC Desc",
        Price = 0,
    };

    public static Product[] Products => new[]
    {
        ProductA,
        ProductB,
    };
}