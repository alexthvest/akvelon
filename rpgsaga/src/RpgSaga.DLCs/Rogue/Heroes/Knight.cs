using RpgSaga.Core.Models;

namespace RpgSaga.DLCs.Rogue.Heroes;

public sealed class Knight : Hero
{
    public Knight(HeroName name, decimal health, decimal attack)
        : base(name, health, attack)
    {
    }

    public static Knight Create(HeroName name, decimal health, decimal attack)
    {
        return new Knight(name, health, attack);
    }
}
