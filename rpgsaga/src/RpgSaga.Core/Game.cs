using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core;

public sealed class Game
{
    private readonly IServiceProvider _serviceProvider;

    internal Game(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static GameBuilder CreateBuilder()
    {
        return new GameBuilder();
    }

    public void Start(byte playerCount)
    {
        var heroes = Enumerable.Range(0, playerCount).Select(i => new Hero($"Hero #{i}"));

        var gameLoop = _serviceProvider.GetRequiredService<IGameLoop>();
        gameLoop.Start(heroes);
    }
}