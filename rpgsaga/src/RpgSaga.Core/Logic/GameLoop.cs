using Microsoft.Extensions.Logging;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;
using RpgSaga.Core.Writers;

namespace RpgSaga.Core.Logic;

internal sealed class GameLoop
{
    private readonly ILogger<GameLoop> _logger;
    private readonly IRoundPairGenerator _roundPairGenerator;
    private readonly IRoundHandler _roundHandler;
    private readonly IWriter _writer;

    public GameLoop(ILogger<GameLoop> logger, IRoundPairGenerator roundPairGenerator, IRoundHandler roundHandler)
    {
        _logger = logger;
        _roundPairGenerator = roundPairGenerator;
        _roundHandler = roundHandler;
        _writer = new ConsoleWriter();
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

                _writer.WriteLine(string.Empty);
                _writer.WriteLine($"👑 Winner: {winner}");

                _logger.LogInformation("Winner of the battle: {@Winner}", winner);
                break;
            }

            heroes = round.Winners;

            _writer.WriteLine(string.Empty);
        }
    }
}
