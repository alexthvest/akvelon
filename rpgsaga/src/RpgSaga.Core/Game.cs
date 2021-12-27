using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Logic;
using RpgSaga.Core.Managment;

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
        var builder = new GameBuilder();

        // Configure services
        builder.Services.AddSingleton<IGameLoop, GameLoop>();
        builder.Services.AddSingleton<IRoundPairGenerator, RoundPairGenerator>();

        return builder;
    }

    public void Start(byte playerCount)
    {
        var gameLoop = _serviceProvider.GetRequiredService<IGameLoop>();
        gameLoop.Start(playerCount);
    }
}