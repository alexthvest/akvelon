using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Repositories;

public interface IProductRepository
{
    IQueryable<Product> GetProducts();

    Task<Product> InsertProductAsync(Product product);
}
