using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Extensions;

namespace RpgSaga.Core;

public sealed class GameBuilder
{
    private readonly ServiceCollection _services = new ();

    public IServiceCollection Services => _services;

    public Game Build()
    {
        var serviceProvider = _services
            .AddRpgSagaCore()
            .BuildServiceProvider();

        return new Game(serviceProvider);
    }
}
