using Microsoft.Extensions.Logging;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Logic;

internal sealed class RoundHandler : IRoundHandler
{
    private readonly ILogger<RoundHandler> _logger;
    private readonly IWriter _writer;
    private readonly IDuelHandler _duelHandler;

    public RoundHandler(ILogger<RoundHandler> logger, IWriter writer, IDuelHandler duelHandler)
    {
        _logger = logger;
        _writer = writer;
        _duelHandler = duelHandler;
    }

    public GameRound Handle(IEnumerable<Hero[]> pairs)
    {
        _writer.WriteLine("===== Round =====");
        _logger.LogInformation("Round has been started");

        var duels = pairs.Select(p => _duelHandler.Handle(p));
        return new GameRound(duels);
    }
}
