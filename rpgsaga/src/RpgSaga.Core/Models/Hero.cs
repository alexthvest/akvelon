namespace RpgSaga.Core.Models;

public abstract class Hero
{
    public Hero(string firstName, string lastName, double health, double attack)
    {
        FirstName = firstName;
        LastName = lastName;
        Health = health;
        Attack = attack;
    }

    public string FirstName { get; }

    public string LastName { get; }

    public double Health { get; }

    public double Attack { get; }

    public override string ToString()
    {
        var role = GetType().Name;
        var name = $"{FirstName} {LastName}";

        return $"{name} ({role})";
    }
}
