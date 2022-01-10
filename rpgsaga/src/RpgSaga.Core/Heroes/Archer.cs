using RpgSaga.Core.Abilities.FireArrows;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Heroes;

public sealed class Archer : Hero
{
    public Archer(HeroName name, decimal health, decimal attack) 
        : base(name, health, attack)
    {
        AddAbility<FireArrowsAbility>();
    }

    public static Archer Create(HeroName name, decimal health, decimal attack)
    {
        return new Archer(name, health, attack);
    }
}
