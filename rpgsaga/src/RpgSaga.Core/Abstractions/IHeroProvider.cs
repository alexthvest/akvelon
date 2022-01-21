using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface IHeroProvider
{
    IReadOnlyCollection<Hero> ResolveHeroes();
}
