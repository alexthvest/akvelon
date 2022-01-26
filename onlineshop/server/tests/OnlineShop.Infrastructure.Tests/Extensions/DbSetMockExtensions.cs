using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace OnlineShop.Infrastructure.Tests.Extensions;

internal static class DbSetMockExtensions
{
    public static void SetupSource<TEntity>(this Mock<DbSet<TEntity>> mock, IQueryable<TEntity> source)
        where TEntity : class
    {
        mock.As<IQueryable<TEntity>>().Setup(m => m.Provider)
            .Returns(source.Provider);

        mock.As<IQueryable<TEntity>>().Setup(m => m.Expression)
            .Returns(source.Expression);

        mock.As<IQueryable<TEntity>>().Setup(m => m.ElementType)
            .Returns(source.ElementType);

        mock.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator())
            .Returns(source.GetEnumerator());
    }
}
