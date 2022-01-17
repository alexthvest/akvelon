using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Extensions;
using RpgSaga.Core.Models;
using RpgSaga.Core.Readers;

namespace RpgSaga.Core.Managment;

internal class ConsoleHeroProvider : IHeroProvider
{
    private readonly CommandLineArgsAccessor _commandLineArgsAccessor;
    private readonly IHeroGenerator _heroGenerator;
    private readonly IHeroStorage _heroStorage;
    private readonly IRandomNameGenerator _randomNameGenerator;

    public ConsoleHeroProvider(
        CommandLineArgsAccessor commandLineArgsAccessor,
        IHeroGenerator heroGenerator,
        IHeroStorage heroStorage,
        IRandomNameGenerator randomNameGenerator)
    {
        _commandLineArgsAccessor = commandLineArgsAccessor;
        _heroGenerator = heroGenerator;
        _heroStorage = heroStorage;
        _randomNameGenerator = randomNameGenerator;
    }

    public IReadOnlyCollection<Hero> ResolveHeroes()
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

        return Enumerable.Range(0, heroesCount.Value).Select(_ =>
        {
            var heroType = _heroStorage.Heroes.GetRandomValue();
            var heroName = _randomNameGenerator.Generate();

            return _heroGenerator.Generate(heroType, heroName);
        }).ToArray();
    }
}
