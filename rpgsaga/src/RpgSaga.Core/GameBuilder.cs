using Microsoft.Extensions.DependencyInjection;

namespace RpgSaga.Core;

public sealed class GameBuilder
{
    private readonly ServiceCollection _services = new ();

    public IServiceCollection Services => _services;

    public Game Build()
    {
        var serviceProvider = _services.BuildServiceProvider();
        return new Game(serviceProvider);
    }
}
