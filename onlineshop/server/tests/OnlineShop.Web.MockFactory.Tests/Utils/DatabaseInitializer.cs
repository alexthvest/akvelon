using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop.Infrastructure.Data;
using WebAPI.MockFactory.Tests.Factory.Interfaces;

namespace OnlineShop.Web.MockFactory.Tests.Utils;

public sealed class DatabaseInitializer : IDatabaseInitializer
{
    private readonly ILogger<DatabaseInitializer> _logger;
    private readonly ApplicationDbContext _context;

    public DatabaseInitializer(ILoggerFactory loggerFactory, IRepositoryContextFactory repositoryContextFactory)
    {
        _logger = loggerFactory.CreateLogger<DatabaseInitializer>();
        _context = repositoryContextFactory.CreateDatabaseContext();
    }

    public void InitializeDatabase(Action<ILogger<DatabaseInitializer>, ApplicationDbContext> initializeAction)
    {
        try
        {
            _context.Database.OpenConnection();
            _context.Database.EnsureCreated();
            _logger.LogInformation("Database initialization started.");
            initializeAction?.Invoke(_logger, _context);
            _logger.LogInformation("Database initialization finished.");
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            _logger.LogInformation("Database initialization failed.");
        }
    }
}