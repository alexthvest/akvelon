using RpgSaga.Core.Models;

namespace RpgSaga.DLCs.Rogue.Heroes;

public sealed class Mage : Hero
{
    public Mage(HeroName name, decimal health, decimal attack) 
        : base(name, health, attack)
    {
    }

    public static Mage Create(HeroName name, decimal health, decimal attack)
    {
        return new Mage(name, health, attack);
    }
}
