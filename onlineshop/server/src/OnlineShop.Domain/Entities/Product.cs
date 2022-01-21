namespace OnlineShop.Domain.Entities;

public class Product : Entity<Guid>
{
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public decimal Price { get; set; }

    public bool Deleted { get; private set; }

    public void MarkDeleted() => Deleted = true;
}
