using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Managment;

internal sealed class RoundPairGenerator : IRoundPairGenerator
{
    public IEnumerable<Hero[]> Generate(IEnumerable<Hero> heroes)
    {
        var pairs = heroes
            .OrderBy(_ => Random.Shared.Next())
            .Chunk(2);

        return pairs.Select(p => p.ToArray());
    }
}
