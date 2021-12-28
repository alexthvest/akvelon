using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;
using RpgSaga.Core.Writers;

namespace RpgSaga.Core.Logic;

internal sealed class RoundHandler : IRoundHandler
{
    private readonly IDuelHandler _duelHandler;
    private readonly IWriter _writer;

    public RoundHandler(IDuelHandler duelHandler)
    {
        _duelHandler = duelHandler;
        _writer = new ConsoleWriter();
    }

    public GameRound Handle(IEnumerable<Hero[]> pairs)
    {
        _writer.WriteLine("=== Round ===");

        var duels = pairs.Select(p => _duelHandler.Handle(p));
        return new GameRound(duels);
    }
}
