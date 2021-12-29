using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Extensions;

namespace RpgSaga.Core;

public sealed class GameBuilder
{
    private readonly Action<GameConfiguration>? _configure;
    private readonly ServiceCollection _services = new ();

    public GameBuilder(Action<GameConfiguration>? configure = default)
    {
        _configure = configure;
    }

    public IServiceCollection Services => _services;

    public Game Build()
    {
        var serviceProvider = _services
            .AddRpgSagaCore()
            .BuildServiceProvider();

        var configuration = serviceProvider.GetRequiredService<GameConfiguration>();

        configuration.ConfigureGameDefaults();

        _configure?.Invoke(configuration);

        return new Game(serviceProvider);
    }
}
