using RpgSaga.Core.Tests.Data;
using Xunit;

namespace RpgSaga.Core.Tests.Models;

public class HeroTests
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 0)]
    [InlineData(0, 0)]
    public void ShouldThrowException_WhenHealthOrAttackLessOrEqualsZero(decimal health, decimal attack)
    {
        // Arrange and Act
        void Action()
        {
            _ = new DummyHero(health, attack);
        }

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(Action);
    }
}
