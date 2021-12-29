using System.Collections.Immutable;

namespace RpgSaga.Core.Abstractions;

public interface IHeroStorage
{
    ImmutableArray<string> Heroes { get; }

    void Add<T>(HeroFactory heroFactory);

    HeroFactory? GetHeroFactory(string heroType);
}
