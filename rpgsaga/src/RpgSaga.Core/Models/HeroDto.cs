namespace RpgSaga.Core.Models;

internal class HeroDto
{
    public HeroDto(string type, HeroName name, decimal health, decimal attack)
    {
        Type = type;
        Name = name;
        Health = health;
        Attack = attack;
    }

    public string Type { get; }

    public HeroName Name { get; }

    public decimal Health { get; }

    public decimal Attack { get; }
}
