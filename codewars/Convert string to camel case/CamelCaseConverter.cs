using System.Text;

namespace ConvertToCamelCase;

internal static class CamelCaseConverter
{
    public static string Convert(string value)
    {
        var builder = new StringBuilder();
        var shouldUppercase = false;

        for (var i = 0; i < value.Length; i++)
        {
            var @char = value[i];

            if (@char == '-' || @char == '_')
            {
                shouldUppercase = true;
                continue;
            }

            @char = shouldUppercase ? char.ToUpperInvariant(@char) : @char;
            builder.Append(@char);

            shouldUppercase = false;
        }

        return builder.ToString();
    }
}