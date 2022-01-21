using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core;

public class GameConfiguration
{
    private readonly IHeroStorage _heroStorage;
    private readonly IAbilityStorage _abilityStorage;
    private readonly IEffectStorage _effectStorage;

    public GameConfiguration(IHeroStorage heroStorage, IAbilityStorage abilityStorage, IEffectStorage effectStorage)
    {
        _heroStorage = heroStorage;
        _abilityStorage = abilityStorage;
        _effectStorage = effectStorage;
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
    
    public void AddEffect<TEffect, TEffectHandler>()
        where TEffect : IEffect, new()
        where TEffectHandler : IEffectHandler<TEffect>
    {
        _effectStorage.Add<TEffect, TEffectHandler>();
    }
}