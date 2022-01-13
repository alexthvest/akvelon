using System.Text.Json;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;
using RpgSaga.Core.Readers;

namespace RpgSaga.Core.Managment;

internal class FileHeroProvider : IHeroProvider
{
    private readonly IHeroStorage _heroStorage;
    private readonly CommandLineArgsAccessor _commandLineArgsAccessor;

    public FileHeroProvider(IHeroStorage heroStorage, CommandLineArgsAccessor commandLineArgsAccessor)
    {
        _heroStorage = heroStorage;
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

        var heroDtos = JsonSerializer.Deserialize<IEnumerable<HeroDto>>(heroesRaw);

        if (heroDtos is null)
        {
            throw new InvalidDataException("Failed to deserialize heroes");
        }

        foreach (var heroDto in heroDtos)
        {
            if (_heroStorage.GetHeroFactory(heroDto.Type) is not { } heroFactory)
            {
                throw new KeyNotFoundException($"Hero '{heroDto.Type} not found'");
            }

            yield return heroFactory.Invoke(heroDto.Name, heroDto.Health, heroDto.Attack);
        }
    }
}
