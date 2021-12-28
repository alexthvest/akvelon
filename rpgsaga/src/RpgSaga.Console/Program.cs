using RpgSaga.Core;
using RpgSaga.DLCs.Rogue.Heroes;

namespace RpgSaga.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        var gameBuilder = Game.CreateBuilder();
        var game = gameBuilder.Build();

        game.Heroes.Add<Archer>(Archer.Create);
        game.Heroes.Add<Knight>(Knight.Create);
        game.Heroes.Add<Mage>(Mage.Create);

        var playerCount = ReadPlayerNumber("Enter number of players: ");
        game.Start(playerCount);
    }

    private static byte ReadPlayerNumber(string message)
    {
        while (true)
        {
            System.Console.Write(message);

            if (byte.TryParse(System.Console.ReadLine(), out var playerCount) && playerCount > 0)
            {
                return playerCount;
            }
        }
    }
}