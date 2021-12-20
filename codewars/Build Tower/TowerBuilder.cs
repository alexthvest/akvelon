namespace BuildTower;

internal static class TowerBuilder
{
    public static string[] Build(int floors)
    {
        var tower = new string[floors];

        for (var i = 1; i <= floors; i++)
        {
            var floor = new string('*', i * 2 - 1);
            var padding = new string(' ', floors - i);

            tower[i - 1] = padding + floor + padding;
        }

        return tower;
    }
}