using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;

namespace OnlineShop.Infrastructure.Data.Repositories;

internal class ProductRepository : IProductRepository
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

    public async Task<Product> InsertProductAsync(Product product)
    {
        var entity = await _context.Products.AddAsync(product);
        
        await _context.SaveChangesAsync();

        return entity.Entity;
    }
}