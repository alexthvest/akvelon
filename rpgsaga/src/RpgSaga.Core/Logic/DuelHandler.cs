using Microsoft.Extensions.Logging;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;
using RpgSaga.Core.Writers;

namespace RpgSaga.Core.Logic;

internal sealed class DuelHandler : IDuelHandler
{
    private readonly ILogger<DuelHandler> _logger;
    private readonly IWriter _writer;

    public DuelHandler(ILogger<DuelHandler> logger)
    {
        _logger = logger;
        _writer = new ConsoleWriter();
    }

    /// <summary>
    /// Handles battle logic between two heroes.
    /// </summary>
    /// <param name="heroes">Pair of heroes.</param>
    /// <returns>Result of battle containing heroes and winner of the duel.</returns>
    public GameDuel Handle(Hero[] heroes)
    {
        if (heroes.Length == 0)
        {
            throw new ArgumentOutOfRangeException("Pair must consists of one or two heroes");
        }

        if (heroes.Length == 1)
        {
            return new GameDuel(heroes, heroes[0]);
        }

        _writer.WriteLine($">>> {heroes[0]} vs {heroes[1]}");
        _logger.LogInformation("Duel between two heroes begin: {Heroes}", heroes);

        var winner = heroes.MaxBy(p => p.Health + p.Attack);

        return new GameDuel(heroes, winner!);
    }
}
