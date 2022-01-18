using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Extensions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Managment;

internal class RandomHeroGenerator : IRandomHeroGenerator
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

        var name = _randomNameGenerator.Generate();

        var health = Random.Shared.Next(10, 80);
        var attack = Random.Shared.Next(4, health / 2);

        return heroFactory.Invoke(name, health, attack);
    }
}
