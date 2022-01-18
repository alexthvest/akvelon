using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Managment;

internal sealed class HeroGenerator : IHeroGenerator
{
    private readonly IHeroStorage _heroStorage;

    public HeroGenerator(IHeroStorage heroStorage)
    {
        _heroStorage = heroStorage;
    }

    public Hero Generate(string heroType, HeroName name)
    {
        var heroFactory = _heroStorage.GetHeroFactory(heroType);

        if (heroFactory is null)
        {
            throw new KeyNotFoundException($"Hero '{heroType}' is not registered in storage");
        }

        var health = Random.Shared.Next(10, 120);
        var attack = Random.Shared.Next(health / 10, health);

        return heroFactory.Invoke(name, health, attack);
    }
}
