using RpgSaga.Core.Heroes;

namespace RpgSaga.Core;

internal static class DefaultGameConfiguration
{
    public static void ConfigureGameDefaults(this GameConfiguration configuration)
    {
        configuration.AddHero<Archer>(Archer.Create);
        configuration.AddHero<Knight>(Knight.Create);
        configuration.AddHero<Mage>(Mage.Create);
    }
}
