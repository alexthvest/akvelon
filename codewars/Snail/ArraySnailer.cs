namespace Snail;

internal static class ArraySnailer
{
    public static int[] Snail(int[][] array)
    {
        if (array.Length == 0)
        {
            return Array.Empty<int>();
        }

        var yLength = array.Length;
        var xLength = array[0].Length;
        var length = yLength * xLength;

        var snailedArray = new int[length];
        var steps = 0;

        var xOffset = 0;
        var yOffset = 0;

        while (steps < length)
        {
            for (var i = xOffset; i < array[yOffset].Length - xOffset; i++)
            {
                snailedArray[steps++] = array[yOffset][i];
            }

            yOffset++;

            for (var i = yOffset; i < array.Length - yOffset + 1; i++)
            {
                snailedArray[steps++] = array[i][^(xOffset + 1)];
            }

            xOffset++;

            for (var i = xLength - xOffset - 1; i >= xOffset - 1; i--)
            {
                snailedArray[steps++] = array[^yOffset][i];
            }

            for (var i = yLength - yOffset - 1; i >= yOffset; i--)
            {
                snailedArray[steps++] = array[i][xOffset - 1];
            }
        }

        return snailedArray;
    }
}