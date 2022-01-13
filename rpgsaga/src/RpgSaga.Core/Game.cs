using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Logic;
using RpgSaga.Core.Models;
using RpgSaga.Core.Readers;

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
        return new GameBuilder(args);
    }

    public void Start()
    {
        var commandLineArgsAccessor = _serviceProvider.GetRequiredService<CommandLineArgsAccessor>();
        var commandLineArgs = commandLineArgsAccessor.Args;

        IReader reader = new ConsoleReader("Enter number of heroes: ");

        if (commandLineArgs.Contains("-c"))
        {
            reader = new CommandLineArgsReader(commandLineArgs, "-c");
        }

        var heroesCount = reader.ReadByte();

        if (!heroesCount.HasValue || heroesCount < 2)
        {
            throw new ArgumentOutOfRangeException("Please enter valid number of heroes that greater or equals 2");
        }

        var heroes = Enumerable.Range(0, heroesCount.Value).Select(i => new Hero($"Hero #{i}"));

        var gameLoop = ActivatorUtilities.CreateInstance<GameLoop>(_serviceProvider);
        gameLoop.Start(heroes);
    }
}
