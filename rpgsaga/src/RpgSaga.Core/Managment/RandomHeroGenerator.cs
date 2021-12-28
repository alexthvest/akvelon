using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Extensions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Managment;

internal sealed class RandomHeroGenerator : IRandomHeroGenerator
{
    private readonly IHeroStorage _heroStorage;
    private readonly IRandomNameGenerator _randomNameGenerator;

    public RandomHeroGenerator(IHeroStorage heroStorage, IRandomNameGenerator randomNameGenerator)
    {
        _heroStorage = heroStorage;
        _randomNameGenerator = randomNameGenerator;
    }

    public Hero Generate()
    {
        var heroType = _heroStorage.Heroes.GetRandomValue();
        var heroFactory = _heroStorage.GetHeroFactory(heroType);

        if (heroFactory is null)
        {
            throw new KeyNotFoundException($"Hero '{heroType}' is not registered in storage");
        }

        var (firstName, lastName) = _randomNameGenerator.Generate();

        var health = Random.Shared.Next(10, 120);
        var attack = Random.Shared.Next(health / 10, health);

        return heroFactory.Invoke(firstName, lastName, health, attack);
    }
}
