using Microsoft.Extensions.Logging;
using OnlineShop.Infrastructure.Data;

namespace OnlineShop.Web.MockFactory.Tests.Utils;

public interface IDatabaseInitializer
{
    void InitializeDatabase(Action<ILogger<DatabaseInitializer>, ApplicationDbContext> initializeAction);
}