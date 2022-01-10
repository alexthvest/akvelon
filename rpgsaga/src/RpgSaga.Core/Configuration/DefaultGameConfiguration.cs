using RpgSaga.Core.Abilities.Bewitchment;
using RpgSaga.Core.Abilities.FireArrows;
using RpgSaga.Core.Abilities.Nemesis;
using RpgSaga.Core.Heroes;

namespace RpgSaga.Core;

internal static class DefaultGameConfiguration
{
    public static void ConfigureGameDefaults(this GameConfiguration configuration)
    {
        configuration.AddHero<Archer>(Archer.Create);
        configuration.AddHero<Knight>(Knight.Create);
        configuration.AddHero<Mage>(Mage.Create);

        configuration.AddAbility<BewitchmentAbility, BewitchmentAbilityHandler>();
        configuration.AddAbility<FireArrowsAbility, FireArrowsAbilityHandler>();
        configuration.AddAbility<NemesisAbility, NemesisAbilityHandler>();
    }
}
