using Moq;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Heroes;
using RpgSaga.Core.Managment;
using RpgSaga.Core.Tests.Data;
using Xunit;

namespace RpgSaga.Core.Tests.Managment;

public class RandomHeroGeneratorTests
{
    [Fact]
    public void ShouldReturn_SpecificHeroInstance_ByHeroName()
    {
        // Arrange
        var randomNameGeneratorMock = Mock.Of<IRandomNameGenerator>();
        var heroStorageMock = new Mock<IHeroStorage>();

        heroStorageMock.SetupGet(x => x.Heroes)
            .Returns(TestData.DefaultHeroes.Keys);

        heroStorageMock.Setup(x => x.GetHeroFactory(It.IsAny<string>()))
            .Returns(Archer.Create);

        var randomHeroGenerator = new RandomHeroGenerator(heroStorageMock.Object, randomNameGeneratorMock);

        // Act
        var hero = randomHeroGenerator.Generate();

        // Assert
        Assert.IsType<Archer>(hero);
    }
}
