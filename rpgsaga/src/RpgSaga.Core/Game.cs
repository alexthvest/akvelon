using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core;

public sealed class Game
{
    private readonly IServiceProvider _serviceProvider;

    internal Game(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IHeroStorage Heroes => _serviceProvider.GetRequiredService<IHeroStorage>();

    public static GameBuilder CreateBuilder(Action<GameConfiguration>? configure = default)
    {
        return new GameBuilder(configure);
    }

    public void Start(byte playerCount)
    {
        var randomHeroGenerator = _serviceProvider.GetRequiredService<IRandomHeroGenerator>();

        var heroes = Enumerable.Range(0, playerCount).Select(_ => randomHeroGenerator.Generate());

        var gameLoop = _serviceProvider.GetRequiredService<IGameLoop>();
        gameLoop.Start(heroes);
    }
}