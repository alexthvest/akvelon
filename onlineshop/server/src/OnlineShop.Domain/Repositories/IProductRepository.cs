using OnlineShop.Domain.Abstractions;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Repositories;

public interface IProductRepository : IRepository<Product, Guid>
{
}
