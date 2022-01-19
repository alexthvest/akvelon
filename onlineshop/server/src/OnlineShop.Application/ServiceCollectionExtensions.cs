using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.Products.Abstractions;
using OnlineShop.Application.Products.Services;

namespace OnlineShop.Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddScoped<IProductService, ProductService>();
    }
}
