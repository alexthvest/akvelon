namespace WhereMyAnagramsAt;

internal static class AnagramFinder
{
    public static IEnumerable<string> Find(string word, ICollection<string> options)
    {
        var sortedWord = word.OrderBy(c => c);

        foreach (var option in options)
        {
            var sortedOption = option.OrderBy(c => c);

            if (sortedWord.SequenceEqual(sortedOption))
            {
                yield return option;
            }
        }
    }
}