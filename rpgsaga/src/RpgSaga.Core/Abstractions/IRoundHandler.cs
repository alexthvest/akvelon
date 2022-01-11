using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface IRoundHandler
{
    /// <summary>
    /// Handles single round between heroes, runs duels between pairs of heroes.
    /// </summary>
    /// <param name="heroes">Pairs of heroes that participate in round.</param>
    /// <returns>Result of round containing duels of pair of heroes.</returns>
    GameRound Handle(IEnumerable<Hero[]> heroes);
}
