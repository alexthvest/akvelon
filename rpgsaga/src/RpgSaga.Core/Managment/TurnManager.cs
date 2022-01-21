using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Managment;

internal class TurnManager : ITurnManager
{
    private readonly HeroState[] _heroStates;
    private int _position;

    public TurnManager(HeroState[] heroStates)
    {
        _heroStates = heroStates;
    }

    public HeroState Owner => Peek(0);

    public HeroState Target => Peek(1);

    public void NextTurn()
    {
        _position = (_position + 1) % _heroStates.Length;
    }

    private HeroState Peek(int offset)
    {
        var index = (_position + offset) % _heroStates.Length;
        return _heroStates[index];
    }
}