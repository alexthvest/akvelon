using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
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

    internal Game(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static GameBuilder CreateBuilder(string[] args, Action<GameConfiguration>? configure = default)
    {
        return new GameBuilder(args, configure);
    }

    public void Start()
    {
        var commandLineArgsAccessor = _serviceProvider.GetRequiredService<CommandLineArgsAccessor>();
        var commandLineArgs = commandLineArgsAccessor.Args;

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

    private static void SaveHeroes(string[] commandLineArgs, IEnumerable<Hero> heroes)
    {
        var outputPathReader = new CommandLineArgsReader(commandLineArgs, "-o");

        var heroDtos = heroes.Select(hero =>
        {
            var type = hero.GetType().Name;
            return new HeroDto(type, hero.Name, hero.Health, hero.Attack);
        }).ToArray();

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
