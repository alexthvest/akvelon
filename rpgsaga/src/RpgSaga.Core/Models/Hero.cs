namespace RpgSaga.Core.Models;

public abstract class Hero
{
    public Hero(string firstName, string lastName, decimal health, decimal attack)
    {
        FirstName = firstName;
        LastName = lastName;
        Health = health;
        Attack = attack;
    }

    public string FirstName { get; }

    public string LastName { get; }

    public decimal Health { get; }

    public decimal Attack { get; }

    public override string ToString()
    {
        var role = GetType().Name;
        var name = $"{FirstName} {LastName}";

        return $"{name} ({role})";
    }
}
