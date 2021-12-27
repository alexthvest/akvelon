namespace RpgSaga.Core;

public sealed class Game
{
    private readonly IServiceProvider _serviceProvider;

    internal Game(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static GameBuilder CreateBuilder()
    {
        return new GameBuilder();
    }

    public void Start(byte playerCount)
    {
        Console.WriteLine(playerCount);
    }
}