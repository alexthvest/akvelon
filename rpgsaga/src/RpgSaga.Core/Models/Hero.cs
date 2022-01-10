using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Models;

public abstract class Hero
{
    private readonly List<Type> _abilities = new ();

    public Hero(HeroName name, decimal health, decimal attack)
    {
        Name = name;
        Health = health;
        Attack = attack;
    }

    public HeroName Name { get; }

    public decimal Health { get; }

    public decimal Attack { get; }

    public IReadOnlyCollection<Type> Abilities => _abilities;

    public override string ToString()
    {
        var role = GetType().Name;
        var name = $"{Name.FirstName} {Name.LastName}";

        return $"{name} ({role})";
    }

    protected void AddAbility<TAbility>()
        where TAbility : IAbility, new()
    {
        _abilities.Add(typeof(TAbility));
    }
}
