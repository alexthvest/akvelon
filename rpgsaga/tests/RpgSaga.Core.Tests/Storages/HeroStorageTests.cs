using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Heroes;
using RpgSaga.Core.Storages;
using RpgSaga.Core.Tests.Data;
using Xunit;

namespace RpgSaga.Core.Tests.Storages;

public class HeroStorageTests
{
    [Fact]
    public void ShouldAppend_HeroToCollection_ByHeroClassName()
    {
        // Arrange
        var heroStorage = CreateDefaultHeroStorage();

        // Act
        heroStorage.Add<DummyHero>((_, _, _) => new DummyHero());

        // Assert
        Assert.Contains(nameof(DummyHero), heroStorage.Heroes);
    }

    [Fact]
    public void ShouldReturn_ValidHeroFactory_ByHeroName()
    {
        // Arrange
        var heroStorage = CreateDefaultHeroStorage();
        heroStorage.Add<Archer>(Archer.Create);

        // Act
        var heroFactory = heroStorage.GetHeroFactory(nameof(Archer));

        // Assert
        Assert.Equal(Archer.Create, heroFactory);
    }

    private IHeroStorage CreateDefaultHeroStorage()
    {
        return new HeroStorage();
    }
}
