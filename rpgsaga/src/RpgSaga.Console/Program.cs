using RpgSaga.Core;
using RpgSaga.DLCs.Rogue.Heroes;

namespace RpgSaga.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        var gameBuilder = Game.CreateBuilder(args);
        var game = gameBuilder.Build();

        game.Heroes.Add<Archer>(Archer.Create);
        game.Heroes.Add<Knight>(Knight.Create);
        game.Heroes.Add<Mage>(Mage.Create);

        game.Start();
    }
}
