using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface IDuelHandler
{
    /// <summary>
    /// Handles battle logic between two heroes.
    /// </summary>
    /// <param name="heroes">Pair of heroes.</param>
    /// <returns>Result of battle containing heroes and winner of the duel.</returns>
    GameDuel Handle(Hero[] heroes);
}
