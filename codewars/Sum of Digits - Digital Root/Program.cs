namespace DigitalRoot;

internal class Program
{
    private static void Main(string[] args)
    {
        var value = 493193;
        var result = RecursiveDigitSummer.Sum(value);

        Console.WriteLine(result);
    }
}