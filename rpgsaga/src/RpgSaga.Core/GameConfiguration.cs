using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core;

public class GameConfiguration
{
    private readonly IHeroStorage _heroStorage;
    private readonly IAbilityStorage _abilityStorage;

    public GameConfiguration(IHeroStorage heroStorage, IAbilityStorage abilityStorage)
    {
        _heroStorage = heroStorage;
        _abilityStorage = abilityStorage;
    }

    public void AddHero<THero>(HeroFactory heroFactory)
        where THero : Hero
    {
        _heroStorage.Add<THero>(heroFactory);
    }

    public void AddAbility<TAbility, TAbilityHandler>()
        where TAbility : IAbility, new()
        where TAbilityHandler : IAbilityHandler<TAbility>
    {
        _abilityStorage.Add<TAbility, TAbilityHandler>();
    }
}