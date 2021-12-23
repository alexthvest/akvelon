namespace DigitalRoot;

internal static class RecursiveDigitSummer
{
    public static int Sum(long value)
    {
        if (value < 10)
        {
            return (int)value;
        }

        var accumulator = 0;
        while (value > 0)
        {
            accumulator += (int)(value % 10);
            value /= 10;
        }

        return Sum(accumulator);
    }
}