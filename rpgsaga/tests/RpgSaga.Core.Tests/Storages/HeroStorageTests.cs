using RpgSaga.Core.Heroes;
using RpgSaga.Core.Storages;
using Xunit;

namespace RpgSaga.Core.Tests.Storages;

public sealed class HeroStorageTests
{
    [Fact]
    public void GetHeroFactory_Should_Return_Valid_Hero_Factory()
    {
        // Arrange
        var heroStorage = new HeroStorage();

        heroStorage.Add<Archer>(Archer.Create);

        // Act
        var heroFactory = heroStorage.GetHeroFactory(nameof(Archer));

        // Assert
        Assert.Equal(Archer.Create, heroFactory);
    }
}
