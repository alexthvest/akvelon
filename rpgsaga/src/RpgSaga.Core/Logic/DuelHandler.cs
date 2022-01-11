using Microsoft.Extensions.Logging;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Logic;

internal sealed class DuelHandler : IDuelHandler
{
    private readonly ILogger _logger;

    public DuelHandler(ILogger<DuelHandler> logger)
    {
        _logger = logger;
    }

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

        _logger.LogInformation(">>> {0} vs {1}", heroes[0], heroes[1]);

        var winner = heroes.MaxBy(p => p.Health + p.Attack);

        return new GameDuel(heroes, winner!);
    }
}
