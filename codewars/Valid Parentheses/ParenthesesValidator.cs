namespace ValidParentheses;

internal static class ParenthesesValidator
{
    public static bool Validate(string input)
    {
        var stack = new Stack<char>();

        foreach (var @char in input)
        {
            if (@char == '(')
            {
                stack.Push(@char);
            }

            if (@char == ')')
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                stack.Pop();
            }
        }

        return stack.Count == 0;
    }
}
