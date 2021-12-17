namespace FindMissingLetter;

internal class Program
{
    private static void Main(string[] args)
    {
        var sequence = new[] { 'O', 'Q', 'R', 'S' };
        var result = MissingLetterFinder.Find(sequence);

        Console.WriteLine(result);
    }
}