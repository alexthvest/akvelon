namespace FindMissingLetter;

internal static class MissingLetterFinder
{
    public static char? Find(char[] sequence)
    {
        for (var i = 1; i < sequence.Length; i++)
        {
            var previous = (int)sequence[i - 1];
            var current = (int)sequence[i];

            if (current - previous > 1)
            {
                return (char)(previous + 1);
            }
        }

        return null;
    }
}