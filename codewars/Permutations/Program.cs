namespace Permutations;

internal class Program
{
    private static void Main(string[] args)
    {
        var value = "aabb";
        var permutations = Permutations.SinglePermutations(value);

        Console.WriteLine(string.Join(", ", permutations));
    }
}