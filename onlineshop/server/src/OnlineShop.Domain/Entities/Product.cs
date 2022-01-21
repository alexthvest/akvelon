namespace OnlineShop.Domain.Entities;

public class Product : Entity<Guid>
{
    public string Name { get; init; } = default!;

    public string Description { get; init; } = default!;

    public decimal Price { get; init; }
}
