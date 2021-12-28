using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Logic;

internal sealed class DuelHandler : IDuelHandler
{
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

        Console.WriteLine($">>> {heroes[0]} vs {heroes[1]}");

        var winner = heroes.MaxBy(p => p.Health + p.Attack);

        return new GameDuel(heroes, winner!);
    }
}
