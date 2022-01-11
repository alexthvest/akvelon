using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Writers;

internal class ConsoleWriter : IWriter
{
    public void WriteLine(string value)
    {
        Console.WriteLine(value);
    }
}