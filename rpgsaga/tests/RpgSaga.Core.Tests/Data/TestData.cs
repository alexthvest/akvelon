using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Heroes;

namespace RpgSaga.Core.Tests.Data;

internal static class TestData
{
    public static Dictionary<string, HeroFactory> DefaultHeroes { get; } = new ()
    {
        [nameof(Archer)] = Archer.Create,
        [nameof(Knight)] = Knight.Create,
        [nameof(Mage)] = Mage.Create,
    };
}
