using Moq;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Heroes;
using RpgSaga.Core.Managment;
using RpgSaga.Core.Models;
using RpgSaga.Core.Tests.Data;
using Xunit;

namespace RpgSaga.Core.Tests.Managment;

public class HeroGeneratorTests
{
    [Fact]
    public void ShouldReturn_SpecificHeroInstance_ByHeroName()
    {
        // Arrange
        var heroType = typeof(Archer).Name;
        var heroName = new HeroName("Hero", "#9");

        var heroStorageMock = new Mock<IHeroStorage>();

        heroStorageMock.SetupGet(x => x.Heroes)
            .Returns(TestData.DefaultHeroes.Keys);

        heroStorageMock.Setup(x => x.GetHeroFactory(heroType))
            .Returns(Archer.Create);

        var randomHeroGenerator = new HeroGenerator(heroStorageMock.Object);

        // Act
        var hero = randomHeroGenerator.Generate(heroType, heroName);

        // Assert
        Assert.IsType<Archer>(hero);
        Assert.Equal(hero.Name, heroName);
    }
}
