using System.Reflection;
using RpgSaga.Core;

namespace RpgSaga;

internal class Program
{
    private static void Main(string[] args)
    {
        var hero = new Hero("Guitar");
        var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

        Console.WriteLine($"Hello, {hero.Name}!");
        Console.WriteLine();
        Console.WriteLine($"AssemblyVersion: {assemblyVersion}");
    }
}
