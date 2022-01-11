using RpgSaga.Core;

namespace RpgSaga.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        var gameBuilder = Game.CreateBuilder(args);
        var game = gameBuilder.Build();

        game.Start();
    }
}
