using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Logic;

internal sealed class GameLoop
{
    private readonly IRoundPairGenerator _roundPairGenerator;
    private readonly IRoundHandler _roundHandler;

    public GameLoop(IRoundPairGenerator roundPairGenerator, IRoundHandler roundHandler)
    {
        _roundPairGenerator = roundPairGenerator;
        _roundHandler = roundHandler;
    }

    public void Start(IEnumerable<Hero> heroes)
    {
        while (true)
        {
            var pairs = _roundPairGenerator.Generate(heroes);
            var round = _roundHandler.Handle(pairs);

            if (round.Winners.Length == 1)
            {
                var winner = round.Winners[0];

                Console.WriteLine();
                Console.WriteLine($"👑 Winner: {winner}");

                break;
            }

            heroes = round.Winners;
            Console.WriteLine();
        }
    }
}
