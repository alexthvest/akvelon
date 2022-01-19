using System.Linq.Expressions;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.Abstractions;

public interface IRepository<TEntity, T>
    where TEntity : Entity<T>
    where T : struct
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    IQueryable<TEntity> Find();

    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    TEntity? FindOne(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
}