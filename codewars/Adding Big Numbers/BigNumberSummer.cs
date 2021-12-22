using System.Text;

namespace AddingBigNumbers;

internal static class BigNumberSummer
{
    public static string Sum(string a, string b)
    {
        var stack = new Stack<char>();
        var length = Math.Max(a.Length, b.Length);

        var remainder = 0;

        for (var i = 0; i < length; i++)
        {
            var left = i < a.Length ? a[^(i + 1)] - '0' : 0;
            var right = i < b.Length ? b[^(i + 1)] - '0' : 0;

            var sum = left + right + remainder;
            if (sum >= 10)
            {
                stack.Push((char)((sum % 10) + '0'));
                remainder = sum / 10;
            }
            else
            {
                stack.Push((char)(sum + '0'));
                remainder = 0;
            }
        }

        if (remainder > 0)
        {
            stack.Push((char)(remainder + '0'));
        }

        return new string(stack.ToArray());
    }
}
