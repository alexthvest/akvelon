using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface IRoundPairGenerator
{
    IEnumerable<Hero[]> Generate(IEnumerable<Hero> heroes);
}