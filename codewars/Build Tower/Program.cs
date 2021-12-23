namespace BuildTower;

internal class Program
{
    private static void Main(string[] args)
    {
        var floors = 7;
        var tower = TowerBuilder.Build(floors);

        Console.WriteLine(string.Join(Environment.NewLine, tower));
    }
}