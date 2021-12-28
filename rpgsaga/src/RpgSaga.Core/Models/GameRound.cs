using System.Collections.Immutable;

namespace RpgSaga.Core.Models;

internal sealed class GameRound
{
    public GameRound(IEnumerable<GameDuel> duels)
    {
        Duels = ImmutableArray.CreateRange(duels);
    }

    public ImmutableArray<GameDuel> Duels { get; }

    public ImmutableArray<Hero> Winners => Duels.Select(d => d.Winner).ToImmutableArray();
}
