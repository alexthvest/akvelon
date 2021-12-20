namespace MovingZerosToTheEnd;

internal static class ZerosMover
{
    public static int[] MoveToEnd(int[] sequence)
    {
        return sequence.OrderBy(x => x == 0).ToArray();
    }
}