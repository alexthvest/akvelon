using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Dto.Response;

public class ProductDto
{
    public ProductDto(Product product)
    {
        Id = product.Id;
        Name = product.Name;
    }

    public int Id { get; }

    public string Name { get; }
}
