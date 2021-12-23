namespace Permutations;

internal static class Permutations
{
    public static IEnumerable<string> SinglePermutations(string value)
    {
        if (value.Length < 2)
        {
            return new[] { value };
        }

        var permutations = new List<string>();

        for (var i = 0; i < value.Length; i++)
        {
            var @char = value[i];

            if (value.IndexOf(@char) != i)
            {
                continue;
            }

            var remainingChars = value[..i] + value[(i + 1)..];

            foreach (var permutation in SinglePermutations(remainingChars))
            {
                permutations.Add(@char + permutation);
            }
        }

        return permutations;
    }
}