using Microsoft.Extensions.Logging;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Logic;

internal sealed class GameLoop : IGameLoop
{
    private readonly ILogger _logger;
    private readonly IRoundPairGenerator _roundPairGenerator;
    private readonly IRoundHandler _roundHandler;

    public GameLoop(ILogger<GameLoop> logger, IRoundPairGenerator roundPairGenerator, IRoundHandler roundHandler)
    {
        _logger = logger;
        _roundPairGenerator = roundPairGenerator;
        _roundHandler = roundHandler;
    }

    public void Start(IEnumerable<Hero> heroes)
    {
        _logger.LogInformation("Number of heroes generated: {Count}", heroes.Count());

        while (true)
        {
            var pairs = _roundPairGenerator.Generate(heroes);
            var round = _roundHandler.Handle(pairs);

            if (round.Winners.Length == 1)
            {
                var winner = round.Winners[0];

                _logger.LogInformation("👑 Winner: {Winner}", winner);

                break;
            }

            heroes = round.Winners;
        } 
    }
}
