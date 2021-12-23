namespace SumOfIntervals;

internal static class IntervalSummer
{
    public static int Sum((int Start, int End)[] intervals)
    {
        var ranges = intervals.SelectMany(i => Enumerable.Range(i.Start, i.End - i.Start));
        return ranges.Distinct().Count();
    }
}
