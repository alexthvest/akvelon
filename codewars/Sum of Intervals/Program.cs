namespace SumOfIntervals;

internal class Program
{
    private static void Main(string[] args)
    {
        var intervals = new[]
        {
            (1, 2), 
            (6, 10), 
            (11, 15)
        };

        var result = IntervalSummer.Sum(intervals);
        Console.WriteLine(result);
    }
}