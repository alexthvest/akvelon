namespace RpgSaga.Core.Models;

public abstract class Hero
{
    public Hero(HeroName name, decimal health, decimal attack)
    {
        Name = name;
        Health = health;
        Attack = attack;
    }

    public HeroName Name { get; }

    public decimal Health { get; }

    public decimal Attack { get; }

    public override string ToString()
    {
        var role = GetType().Name;
        var name = $"{Name.FirstName} {Name.LastName}";

        return $"{name} ({role})";
    }
}
