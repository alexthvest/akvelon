namespace OnlineShop.Domain.Entities;

public class Product : Entity<Guid>
{
    public string Name { get; init; } = default!;
}
