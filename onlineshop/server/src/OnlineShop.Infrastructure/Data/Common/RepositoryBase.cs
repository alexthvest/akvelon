using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Abstractions;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Data.Common;

public abstract class RepositoryBase<TEntity, T> : IRepository<TEntity, T>
    where TEntity : Entity<T>
    where T : struct
{
    private readonly DbContext _context;

    public RepositoryBase(DbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public IQueryable<TEntity> Find()
    {
        return _context.Set<TEntity>().AsNoTracking();
    }

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().Where(predicate).AsNoTracking();
    }

    public TEntity? FindOne(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().FirstOrDefault(predicate);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Entry(entity).State = EntityState.Modified;

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
