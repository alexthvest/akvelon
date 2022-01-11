namespace RpgSaga.Core.Models;

internal class HeroState
{
    private readonly DuelAbility[] _abilities;

    public HeroState(Hero hero)
    {
        Hero = hero;
        Health = hero.Health;

        _abilities = hero.Abilities
            .Select(ability => new DuelAbility(ability))
            .ToArray();
    }

    public Hero Hero { get; }

    public decimal Health { get; private set; }

    public IReadOnlyCollection<DuelAbility> Abilities => _abilities
        .Where(ability => ability.Usages > 0 || ability.Infinite)
        .ToArray();

    public bool IsDead => Health <= 0;

    public static implicit operator Hero(HeroState heroState) => heroState.Hero;

    public void DealDamage(decimal damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Health = 0;
        }
    }

    public override string ToString()
    {
        return Hero.ToString();
    }
}
