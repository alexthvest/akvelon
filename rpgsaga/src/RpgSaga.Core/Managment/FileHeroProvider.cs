using Newtonsoft.Json;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;
using RpgSaga.Core.Readers;

namespace RpgSaga.Core.Managment;

internal class FileHeroProvider : IHeroProvider
{
    private readonly CommandLineArgsAccessor _commandLineArgsAccessor;

    public FileHeroProvider(CommandLineArgsAccessor commandLineArgsAccessor)
    {
        _commandLineArgsAccessor = commandLineArgsAccessor;
    }

    public IEnumerable<Hero> ResolveHeroes()
    {
        var commandLineArgs = _commandLineArgsAccessor.Args;
        var inputPathReader = new CommandLineArgsReader(commandLineArgs, "-i");

        if (inputPathReader.ReadString() is not { } inputPath)
        {
            throw new ArgumentException("Invalid input path");
        }

        var heroesReader = new FileReader(inputPath);

        if (heroesReader.ReadString() is not { } heroesRaw)
        {
            throw new InvalidDataException("Invalid data");
        }

        var heroes = JsonConvert.DeserializeObject<IEnumerable<Hero>>(heroesRaw, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
        });

        if (heroes is null)
        {
            throw new InvalidDataException("Failed to deserialize heroes");
        }

        return heroes;
    }
}
