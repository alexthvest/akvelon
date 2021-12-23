namespace DuplicateEncoder;

internal class Program
{
    private static void Main(string[] args)
    {
        var value = "din";
        var result = DuplicateEncoder.Encode(value);

        Console.WriteLine(result);
    }
}
