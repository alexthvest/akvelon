namespace FibProduct;

internal class Program
{
    private static void Main(string[] args)
    {
        var result = FibProductFinder.Find(4895);

        Console.WriteLine(string.Join(" ", result));
    }
}