using RpgSaga.Core;

namespace RpgSaga.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        var gameBuilder = Game.CreateBuilder();
        var game = gameBuilder.Build();

        game.Start(4);
    }
}