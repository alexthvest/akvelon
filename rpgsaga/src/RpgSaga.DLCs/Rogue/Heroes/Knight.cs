using RpgSaga.Core.Models;

namespace RpgSaga.DLCs.Rogue.Heroes;

public sealed class Knight : Hero
{
    public Knight(string firstName, string lastName, decimal health, decimal attack) 
        : base(firstName, lastName, health, attack)
    {
    }

    public static Knight Create(string firstName, string lastName, decimal health, decimal attack)
    {
        return new Knight(firstName, lastName, health, attack);
    }
}
