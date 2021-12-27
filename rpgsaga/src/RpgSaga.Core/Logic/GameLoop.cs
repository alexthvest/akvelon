using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Logic;

internal sealed class GameLoop : IGameLoop
{
    private readonly IRoundPairGenerator _roundPairGenerator;

    public GameLoop(IRoundPairGenerator roundPairGenerator)
    {
        _roundPairGenerator = roundPairGenerator;
    }

    public void Start(byte playerCount)
    {
        var heroes = Enumerable.Range(0, playerCount).Select(i => new Hero($"Hero #{i}"));
        var pairs = _roundPairGenerator.Generate(heroes);

        foreach (var pair in pairs)
        {
            Console.Write("@Pair [ ");
            Console.Write(string.Join(", ", pair.Select(p => p.Name)));
            Console.WriteLine(" ]");
        }
    }
}
