namespace Snail;

internal class Program
{
    private static void Main(string[] args)
    {
        var array = new int[][]
        {
            new [] { 1, 2, 3 },
            new [] { 4, 5, 6 },
            new [] { 7, 8, 9 }
        };

        var snailedArray = ArraySnailer.Snail(array);
        Console.WriteLine(string.Join(", ", snailedArray));
    }
}