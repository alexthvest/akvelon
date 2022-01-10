namespace RpgSaga.Core.Models;

internal class HeroState
{
    public HeroState(Hero hero)
    {
        Hero = hero;
        Health = hero.Health;
    }

    public Hero Hero { get; }

    public decimal Health { get; private set; }

    public bool IsDead => Health <= 0;

    public static implicit operator Hero(HeroState heroState) => heroState.Hero;

    public void DealDamange(decimal damage)
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
