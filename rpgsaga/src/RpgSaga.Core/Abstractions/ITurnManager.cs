using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface ITurnManager
{
    HeroState Owner { get; }

    HeroState Target { get; }

    void NextTurn();
}
