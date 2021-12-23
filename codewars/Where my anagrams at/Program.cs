namespace WhereMyAnagramsAt;

internal class Program
{
    private static void Main(string[] args)
    {
        var word = "racer";
        var options = new[] { "carer", "arcre", "carre", "racrs", "racers", "arceer", "raccer", "carrer", "cerarr" };

        var anagrams = AnagramFinder.Find(word, options);
        Console.WriteLine(string.Join(", ", anagrams));
    }
}