using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface IRoundHandler
{
    GameRound Handle(IEnumerable<Hero[]> heroes);
}
