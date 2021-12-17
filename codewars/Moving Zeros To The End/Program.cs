namespace MovingZerosToTheEnd;

internal class Program
{
    private static void Main(string[] args)
    {
        var sequence = new[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 };
        var result = ZerosMover.MoveToEnd(sequence);

        Console.WriteLine(string.Join(" ", result));
    }
}