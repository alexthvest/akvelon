using System.Text.Json.Serialization;

namespace RpgSaga.Core.Models;

public abstract class Hero
{
    [JsonConstructor]
    public Hero(HeroName name, decimal health, decimal attack)
    {
        if (health <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(health), "Health must be greater than zero");
        }

        if (attack <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(attack), "Attack must be greater than zero");
        }

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
