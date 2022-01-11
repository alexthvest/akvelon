using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core;

public sealed class GameConfiguration
{
    private readonly IHeroStorage _heroStorage;

    public GameConfiguration(IHeroStorage heroStorage)
    {
        _heroStorage = heroStorage;
    }

    public void AddHero<T>(HeroFactory heroFactory)
        where T : Hero
    {
        _heroStorage.Add<T>(heroFactory);
    }
}