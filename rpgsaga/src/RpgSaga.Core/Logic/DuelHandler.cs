using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;
using RpgSaga.Core.Writers;

namespace RpgSaga.Core.Logic;

internal sealed class DuelHandler : IDuelHandler
{
    private readonly IWriter _writer;

    public DuelHandler()
    {
        _writer = new ConsoleWriter();
    }

    /// <summary>
    /// Handles battle logic between two heroes.
    /// </summary>
    /// <param name="heroes">Pair of heroes.</param>
    /// <returns>Result of battle containing heroes and winner of the duel.</returns>
    public GameDuel Handle(Hero[] heroes)
    {
        if (heroes.Length > 1)
        {
            _writer.WriteLine($">>> {heroes[0].Name} vs {heroes[1].Name}");
        }

        var winner = heroes[Random.Shared.Next(0, heroes.Length)];

        return new GameDuel(heroes, winner);
    }
}
