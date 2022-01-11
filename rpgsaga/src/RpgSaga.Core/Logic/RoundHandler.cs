using Microsoft.Extensions.Logging;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Logic;

internal sealed class RoundHandler : IRoundHandler
{
    private readonly ILogger _logger;
    private readonly IDuelHandler _duelHandler;

    public RoundHandler(ILogger<RoundHandler> logger, IDuelHandler duelHandler)
    {
        _logger = logger;
        _duelHandler = duelHandler;
    }

    public GameRound Handle(IEnumerable<Hero[]> pairs)
    {
        _logger.LogInformation("===== Round =====");

        var duels = pairs.Select(p => _duelHandler.Handle(p));
        return new GameRound(duels);
    }
}
