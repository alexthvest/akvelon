namespace RpgSaga.Core.Extensions;

internal static class EnumerableExtensions
{
    public static T GetRandomValue<T>(this IEnumerable<T> enumerable)
    {
        var index = Random.Shared.Next(0, enumerable.Count());
        return enumerable.ElementAt(index);
    }
}
