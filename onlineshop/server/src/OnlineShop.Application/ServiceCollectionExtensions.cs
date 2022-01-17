using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Abstractions;
using OnlineShop.Application.Services;

namespace OnlineShop.Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }
}
