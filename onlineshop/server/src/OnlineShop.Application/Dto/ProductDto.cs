using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Dto;

public class ProductDto
{
    public ProductDto(Product product)
    {
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string Description { get; }

    public decimal Price { get; }
}
