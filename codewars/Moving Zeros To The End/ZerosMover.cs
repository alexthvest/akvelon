namespace MovingZerosToTheEnd;

internal static class ZerosMover
{
    public static int[] MoveToEnd(int[] sequence)
    {
        var result = new List<int>();
        var zeroCounter = 0;

        foreach (var number in sequence)
        {
            if (number == 0)
            {
                zeroCounter++;
                continue;
            }

            result.Add(number);
        }

        for (var i = 0; i < zeroCounter; i++)
        {
            result.Add(0);
        }

        return result.ToArray();
    }
}