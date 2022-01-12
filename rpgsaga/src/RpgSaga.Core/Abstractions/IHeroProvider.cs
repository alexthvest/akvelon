using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface IHeroProvider
{
    IEnumerable<Hero> ResolveHeroes();
}
