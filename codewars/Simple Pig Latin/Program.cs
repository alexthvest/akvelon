namespace SimplePigLatin;

internal class Program
{
    private static void Main(string[] args)
    {
        var result = PigIt("Pig latin is cool");
        Console.WriteLine(result);
    }

    private static string PigIt(string value)
    {
        var words = value.Split(' ').Select(w => char.IsLetter(w[0]) ? w[1..] + w[0] + "ay" : w);
        return string.Join(' ', words);
    }
}