using RpgSaga.Core.Models;

namespace RpgSaga.Core.Tests.Data;

internal class DummyHero : Hero
{
    public DummyHero() 
        : this(1, 1)
    {
    }

    public DummyHero(decimal health, decimal attack)
        : base(new HeroName("Dummy", "Hero"), health, attack)
    {
    }
}
