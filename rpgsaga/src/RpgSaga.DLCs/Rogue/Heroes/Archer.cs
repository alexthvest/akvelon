using RpgSaga.Core.Models;

namespace RpgSaga.DLCs.Rogue.Heroes;

public sealed class Archer : Hero
{
    public Archer(string firstName, string lastName, double health, double attack) 
        : base(firstName, lastName, health, attack)
    {
    }

    public static Archer Create(string firstName, string lastName, double health, double attack)
    {
        return new Archer(firstName, lastName, health, attack);
    }
}
