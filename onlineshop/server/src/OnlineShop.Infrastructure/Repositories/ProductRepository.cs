using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Contexts;

namespace OnlineShop.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<Product> GetProducts()
    {
        return _context.Products.AsNoTracking();
    }

    public Product InsertProduct(Product product)
    {
        var entity = _context.Products.Add(product);
        _context.SaveChanges();
        return entity.Entity;
    }
}