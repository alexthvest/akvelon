using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Logic;
using RpgSaga.Core.Readers;

namespace RpgSaga.Core;

public sealed class Game
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<Game> _logger;
    private readonly IWriter _writer;
    private readonly IRandomHeroGenerator _randomHeroGenerator;
    private readonly CommandLineArgsAccessor _commandLineArgsAccessor;

    internal Game(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _logger = serviceProvider.GetRequiredService<ILogger<Game>>();
        _writer = serviceProvider.GetRequiredService<IWriter>();
        _randomHeroGenerator = serviceProvider.GetRequiredService<IRandomHeroGenerator>();
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

            var heroes = Enumerable.Range(0, heroesCount.Value).Select(_ => _randomHeroGenerator.Generate());

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
}
