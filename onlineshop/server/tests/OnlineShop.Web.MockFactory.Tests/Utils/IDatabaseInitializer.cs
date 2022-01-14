using Microsoft.Extensions.Logging;
using OnlineShop.Infrastructure.Contexts;

namespace OnlineShop.Web.MockFactory.Tests.Utils;

public interface IDatabaseInitializer
{
    void InitializeDatabase(Action<ILogger<DatabaseInitializer>, ApplicationDbContext> initializeAction);
}