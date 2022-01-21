namespace OnlineShop.Application.Products.Common;

public class ProductDetailsDto
{
    public string Name { get; init; } = default!;

    public string Description { get; init; } = default!;

    public decimal Price { get; init; }
}
