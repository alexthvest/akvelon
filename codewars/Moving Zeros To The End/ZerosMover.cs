namespace MovingZerosToTheEnd;

internal static class ZerosMover
{
    public static int[] MoveToEnd(int[] sequence)
    {
        var resultArray = new int[sequence.Length];
        var currentIndex = 0;

        foreach (var number in sequence)
        { 
            if (number != 0)
            {
                resultArray[currentIndex++] = number;
            }
        }

        for (var i = 0; i < sequence.Length - currentIndex; i++)
        {
            resultArray[currentIndex++] = 0;
        }

        return resultArray;
    }
}