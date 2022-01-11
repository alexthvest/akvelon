using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Logic;

internal sealed class RoundHandler : IRoundHandler
{
    private readonly IDuelHandler _duelHandler;

    public RoundHandler(IDuelHandler duelHandler)
    {
        _duelHandler = duelHandler;
    }

    public GameRound Handle(IEnumerable<Hero[]> pairs)
    {
        Console.WriteLine("=== Round ===");

        var duels = pairs.Select(pair => _duelHandler.Handle(pair));

        return new GameRound(duels);
    }
}
