namespace ConvertToCamelCase;

internal class Program
{
    private static void Main(string[] args)
    {
        var value = "the-stealth-warrior";
        var result = CamelCaseConverter.Convert(value);

        Console.WriteLine(result);
    }
}