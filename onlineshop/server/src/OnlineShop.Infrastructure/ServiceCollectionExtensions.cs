using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Data;
using OnlineShop.Infrastructure.Data.Repositories;

namespace OnlineShop.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNpgsql<ApplicationDbContext>(configuration.GetConnectionString("DefaultConnection"));

        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
