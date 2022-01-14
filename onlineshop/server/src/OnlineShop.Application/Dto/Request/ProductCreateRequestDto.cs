using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Dto.Request;

public class ProductCreateRequestDto : IDtoMapper<Product>
{
    public ProductCreateRequestDto(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public Product ToModel()
    {
        return new Product()
        {
            Name = Name,
        };
    }
}
