using RpgSaga.Core.Models;

namespace RpgSaga.DLCs.Rogue.Heroes;

public sealed class Archer : Hero
{
    public Archer(HeroName name, decimal health, decimal attack) 
        : base(name, health, attack)
    {
    }

    public static Archer Create(HeroName name, decimal health, decimal attack)
    {
        return new Archer(name, health, attack);
    }
}
