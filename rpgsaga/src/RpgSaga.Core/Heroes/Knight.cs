using RpgSaga.Core.Abilities.Nemesis;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Heroes;

internal sealed class Knight : Hero
{
    public Knight(HeroName name, decimal health, decimal attack)
        : base(name, health, attack)
    {
        AddAbility<NemesisAbility>();
    }

    public static Knight Create(HeroName name, decimal health, decimal attack)
    {
        return new Knight(name, health, attack);
    }
}
