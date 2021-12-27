using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Managment;

internal sealed class RoundPairGenerator : IRoundPairGenerator
{
    public IEnumerable<IEnumerable<Hero>> Generate(IEnumerable<Hero> heroes)
    {
        return heroes
            .OrderBy(_ => Random.Shared.Next())
            .Chunk(2);
    }
}
