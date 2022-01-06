using RpgSaga.Core.Models;

namespace RpgSaga.Core.Tests.Data;

internal sealed class DummyHero : Hero
{
    public DummyHero() 
        : base(new HeroName("Dummy", "Hero"), 0, 0)
    {
    }
}
