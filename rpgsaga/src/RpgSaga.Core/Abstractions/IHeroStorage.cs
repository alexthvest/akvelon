namespace RpgSaga.Core.Abstractions;

public interface IHeroStorage
{
    IReadOnlyCollection<string> Heroes { get; }

    void Add<T>(HeroFactory heroFactory);

    HeroFactory? GetHeroFactory(string heroType);
}
