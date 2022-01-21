using AutoMapper;
using OnlineShop.Application.Products.Common;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Common.Mappings;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDetailsDto, Product>();
    }
}
