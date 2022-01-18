using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Logic;
using RpgSaga.Core.Managment;
using RpgSaga.Core.Models;
using RpgSaga.Core.Readers;
using RpgSaga.Core.Writers;

namespace RpgSaga.Core;

public sealed class Game
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<Game> _logger;
    private readonly IWriter _writer;
    private readonly CommandLineArgsAccessor _commandLineArgsAccessor;

    internal Game(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _logger = serviceProvider.GetRequiredService<ILogger<Game>>();
        _writer = serviceProvider.GetRequiredService<IWriter>();
        _commandLineArgsAccessor = serviceProvider.GetRequiredService<CommandLineArgsAccessor>();
    }

    public static GameBuilder CreateBuilder(string[] args, Action<GameConfiguration>? configure = default)
    {
        return new GameBuilder(args, configure);
    }

    public void Start()
    {
        try
        {
            var commandLineArgs = _commandLineArgsAccessor.Args;

            var heroProviderType = typeof(ConsoleHeroProvider);

            if (commandLineArgs.Contains("-i"))
            {
                heroProviderType = typeof(FileHeroProvider);
            }

            if (ActivatorUtilities.CreateInstance(_serviceProvider, heroProviderType) is not IHeroProvider heroProvider)
            {
                throw new Exception("Invalid hero provider type, it should implements IHeroProvider interface");
            }

            var heroes = heroProvider.ResolveHeroes();

            if (commandLineArgs.Contains("-o"))
            {
                SaveHeroes(commandLineArgs, heroes);
            }

            var gameLoop = ActivatorUtilities.CreateInstance<GameLoop>(_serviceProvider);
            gameLoop.Start(heroes);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            _writer.WriteLine("[Error] Invalid argument provider. Please make sure all values are correct");
            Console.ResetColor();

            _logger.LogCritical(e, "Invalid argument provider: {Name}", e.ParamName);
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            _writer.WriteLine("[Error] Failed to start the game. Something went wrong");
            Console.ResetColor();

            _logger.LogCritical(e, "Failed to start the game");
        }
    }

    private static void SaveHeroes(string[] commandLineArgs, IEnumerable<Hero> heroes)
    {
        var outputPathReader = new CommandLineArgsReader(commandLineArgs, "-o");

        var heroDtos = heroes.Select(hero => new HeroDto(hero.GetType().Name, hero.Name)).ToArray();

        if (outputPathReader.ReadString() is not { } outputPath)
        {
            throw new ArgumentException("Invalid path");
        }

        var heroesRaw = JsonSerializer.Serialize(heroDtos, new JsonSerializerOptions
        {
            WriteIndented = true,
        });

        var writer = new FileWriter(outputPath);
        writer.WriteLine(heroesRaw);
    }
}
