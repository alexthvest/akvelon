using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Managment;
using RpgSaga.Core.Tests.Data;
using Xunit;

namespace RpgSaga.Core.Tests.Managment;

public class RoundPairGeneratorTests
{
    [Fact]
    public void ShouldGenerate_EvenNumberOfPairs_WhenHeroesNumberIsEven()
    {
        // Arrange
        var heroes = Enumerable.Range(0, 4).Select(_ => new DummyHero());
        var roundPairGenerator = CreateDefaultRoundPairGenerator();

        // Act
        var pairs = roundPairGenerator.Generate(heroes);

        // Assert
        Assert.Collection(
            pairs,
            item => Assert.Equal(2, item.Length), 
            item => Assert.Equal(2, item.Length));
    }

    [Fact]
    public void ShouldGenerate_PairWithOneHero_WhenNumberOfHeroesIsOdd()
    {
        // Arrange
        var heroes = Enumerable.Range(0, 3).Select(_ => new DummyHero());
        var roundPairGenerator = CreateDefaultRoundPairGenerator();

        // Act
        var pairs = roundPairGenerator.Generate(heroes);

        // Assert
        Assert.Collection(
            pairs,
            item => Assert.Equal(2, item.Length),
            item => Assert.Single(item));
    }

    private IRoundPairGenerator CreateDefaultRoundPairGenerator()
    {
        return new RoundPairGenerator();
    }
}
