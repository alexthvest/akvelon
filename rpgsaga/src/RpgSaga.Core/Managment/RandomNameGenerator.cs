﻿using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Extensions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Managment;

internal sealed class RandomNameGenerator : IRandomNameGenerator
{
    private readonly string[] _firstNames = new[]
    {
        "Bendyboot",
        "Bimplesnitch",
        "Benadonald",
        "Benedeez",
        "Big",
        "Butterfly",
        "Benelit",
        "Battlefield",
        "Benson",
        "Booberry",
        "Benethot",
    };

    private readonly string[] _lastNames = new[]
    {
        "Crumblybuns",
        "Comfortable",
        "Cumberswitch",
        "Thunderpatch",
        "Ben",
        "Tinderbox",
        "Animorph",
        "Overwatch",
        "Censorbar",
        "Dinosaur",
        "Cinnamon",
    };

    public HeroName Generate()
    {
        var firstName = _firstNames.GetRandomValue();
        var lastName = _lastNames.GetRandomValue();

        return new HeroName(firstName, lastName);
    }
}
