using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Responses;

public class ProductResponse
{
    public ProductResponse(Product product)
    {
        Id = product.Id;
        Name = product.Name;
    }

    public Guid Id { get; }

    public string Name { get; }
}
