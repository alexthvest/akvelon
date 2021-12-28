using System.Collections.Immutable;

namespace RpgSaga.Core.Abstractions;

public interface IHeroStorage
{
    ImmutableArray<string> Heroes { get; }

    void Add<T>(HeroFactory factory);

    HeroFactory? GetHeroFactory(string heroType);
}
