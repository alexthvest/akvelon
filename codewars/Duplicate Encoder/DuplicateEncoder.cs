using System.Text;

namespace DuplicateEncoder;

internal static class DuplicateEncoder
{
    public static string Encode(string value)
    {
        value = value.ToLowerInvariant();

        var builder = new StringBuilder();
        var dictionary = new Dictionary<char, int>();

        foreach (var @char in value)
        {
            if (dictionary.ContainsKey(@char))
            {
                dictionary[@char] += 1;
                continue;
            }

            dictionary.Add(@char, 1);
        }

        foreach (var @char in value)
        {
            var paren = dictionary[@char] == 1 ? "(" : ")";
            builder.Append(paren);
        }

        return builder.ToString();
    }
}