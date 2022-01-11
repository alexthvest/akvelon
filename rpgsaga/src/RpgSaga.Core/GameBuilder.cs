using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core;

public sealed class GameBuilder
{
    private readonly ServiceCollection _services = new ();
    private readonly string[] _args;

    public GameBuilder(string[] args)
    {
        _args = args;
    }

    public IServiceCollection Services => _services;

    public Game Build()
    {
        _services.AddSingleton(new CommandLineArgsAccessor(_args));

        var serviceProvider = _services.BuildServiceProvider();
        return new Game(serviceProvider);
    }
}
