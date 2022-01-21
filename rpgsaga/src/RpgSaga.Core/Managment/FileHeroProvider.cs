﻿using System.Text.Json;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;
using RpgSaga.Core.Readers;

namespace RpgSaga.Core.Managment;

internal class FileHeroProvider : IHeroProvider
{
    private readonly IHeroGenerator _heroGenerator;
    private readonly CommandLineArgsAccessor _commandLineArgsAccessor;

    public FileHeroProvider(CommandLineArgsAccessor commandLineArgsAccessor, IHeroGenerator heroGenerator)
    {
        _heroGenerator = heroGenerator;
        _commandLineArgsAccessor = commandLineArgsAccessor;
    }

    public IReadOnlyCollection<Hero> ResolveHeroes()
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

        return heroDtos
            .Select(heroDto => _heroGenerator.Generate(heroDto.Type, heroDto.Name))
            .ToArray();
    }
}