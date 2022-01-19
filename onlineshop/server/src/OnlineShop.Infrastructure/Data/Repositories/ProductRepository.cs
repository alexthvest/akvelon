using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Data.Common;

namespace OnlineShop.Infrastructure.Data.Repositories;

internal class ProductRepository : RepositoryBase<Product, Guid>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) 
        : base(context)
    {
    }
}