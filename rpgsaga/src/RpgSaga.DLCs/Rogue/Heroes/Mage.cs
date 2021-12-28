using RpgSaga.Core.Models;

namespace RpgSaga.DLCs.Rogue.Heroes;

public sealed class Mage : Hero
{
    public Mage(string firstName, string lastName, double health, double attack) 
        : base(firstName, lastName, health, attack)
    {
    }

    public static Mage Create(string firstName, string lastName, double health, double attack)
    {
        return new Mage(firstName, lastName, health, attack);
    }
}
