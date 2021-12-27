using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Logic;
using RpgSaga.Core.Managment;
using RpgSaga.Core.Readers;
using RpgSaga.Core.Writers;

namespace RpgSaga.Core;

public sealed class Game
{
    private readonly IServiceProvider _serviceProvider;

    internal Game(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static GameBuilder CreateBuilder(string[] args)
    {
        var builder = new GameBuilder(args);

        // Configure services
        builder.Services.AddSingleton<IGameLoop, GameLoop>();
        builder.Services.AddSingleton<IRoundPairGenerator, RoundPairGenerator>();

        return builder;
    }

    public void Start()
    {
        var commandLineArgsAccessor = _serviceProvider.GetRequiredService<CommandLineArgsAccessor>();
        var commandLineArgs = commandLineArgsAccessor.Args;

        IWriter writer = new ConsoleWriter();
        IReader reader = new CommandLineArgsReader(commandLineArgs, "-c");

        var heroesCount = reader.ReadByte();

        if (!heroesCount.HasValue || heroesCount < 2)
        {
            throw new Exception("Please enter valid number of heroes that greater or equals 2");
        }

        var gameLoop = _serviceProvider.GetRequiredService<IGameLoop>();
        gameLoop.Start(heroesCount.Value);
    }
}
