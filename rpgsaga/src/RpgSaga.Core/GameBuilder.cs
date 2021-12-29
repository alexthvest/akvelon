using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Extensions;

namespace RpgSaga.Core;

public sealed class GameBuilder
{
    private readonly Action<GameConfiguration>? _configure;
    private readonly ServiceCollection _services = new ();
    private readonly string[] _args;

    public GameBuilder(string[] args, Action<GameConfiguration>? configure = default)
    {
        _args = args;
        _configure = configure;
    }

    public IServiceCollection Services => _services;

    public Game Build()
    {
        _services.AddSingleton(new CommandLineArgsAccessor(_args));

        var serviceProvider = _services
            .AddRpgSagaCore()
            .BuildServiceProvider();

        var configuration = serviceProvider.GetRequiredService<GameConfiguration>();

        configuration.ConfigureGameDefaults();

        _configure?.Invoke(configuration);

        return new Game(serviceProvider);
    }
}
