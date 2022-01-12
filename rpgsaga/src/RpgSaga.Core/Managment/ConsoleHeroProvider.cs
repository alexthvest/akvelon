using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;
using RpgSaga.Core.Readers;

namespace RpgSaga.Core.Managment;

internal class ConsoleHeroProvider : IHeroProvider
{
    private readonly CommandLineArgsAccessor _commandLineArgsAccessor;
    private readonly IRandomHeroGenerator _randomHeroGenerator;

    public ConsoleHeroProvider(CommandLineArgsAccessor commandLineArgsAccessor, IRandomHeroGenerator randomHeroGenerator)
    {
        _commandLineArgsAccessor = commandLineArgsAccessor;
        _randomHeroGenerator = randomHeroGenerator;
    }

    public IEnumerable<Hero> ResolveHeroes()
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

        return Enumerable.Range(0, heroesCount.Value).Select(_ => _randomHeroGenerator.Generate());
    }
}
