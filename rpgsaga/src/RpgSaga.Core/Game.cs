using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Abstractions;
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
        return new GameBuilder(args);
    }

    public void Start()
    {
        var commandLineArgsAccessor = _serviceProvider.GetRequiredService<CommandLineArgsAccessor>();
        var commandLineArgs = commandLineArgsAccessor.Args;

        IWriter writer = new ConsoleWriter();
        IReader reader = new CommandLineArgsReader(commandLineArgs, "-c");

        var heroesCount = reader.ReadByte();

        writer.WriteLine($"Heroes: {heroesCount ?? 0}");
    }
}