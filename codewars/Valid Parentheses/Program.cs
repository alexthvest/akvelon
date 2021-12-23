namespace ValidParentheses;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = ")(()))";
        var isValid = ParenthesesValidator.Validate(input);

        Console.WriteLine(isValid);
    }
}