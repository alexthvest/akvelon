using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Storages;

internal sealed class HeroStorage : IHeroStorage
{
    private readonly Dictionary<string, HeroFactory> _heroFactories = new ();

    public IReadOnlyCollection<string> Heroes => _heroFactories.Keys;

    public void Add<T>(HeroFactory heroFactory)
    {
        _heroFactories[typeof(T).Name] = heroFactory;
    }

    public HeroFactory? GetHeroFactory(string heroType)
    {
        if (_heroFactories.TryGetValue(heroType, out var heroFactory))
        {
            return heroFactory;
        }

        return null;
    }
}
