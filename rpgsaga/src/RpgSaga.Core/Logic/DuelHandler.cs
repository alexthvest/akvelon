using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Logic;

internal sealed class DuelHandler : IDuelHandler
{
    public GameDuel Handle(Hero[] heroes)
    {
        if (heroes.Length > 1)
        {
            Console.WriteLine($">>> {heroes[0].Name} vs {heroes[1].Name}");
        }

        var winner = heroes[Random.Shared.Next(0, heroes.Length)];

        return new GameDuel(heroes, winner);
    }
}
