using System.Collections.Immutable;

namespace RpgSaga.Core.Models;

internal sealed record GameDuel
{
    public GameDuel(IEnumerable<Hero> pair, Hero winner)
    {
        Pair = ImmutableArray.CreateRange(pair);
        Winner = winner;
    }

    public ImmutableArray<Hero> Pair { get; }

    public Hero Winner { get; }
}
