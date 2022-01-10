using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Readers;

internal class ConsoleReader : IReader
{
    public byte? ReadByte()
    {
        var input = ReadString();

        if (byte.TryParse(input, out var value))
        {
            return value;
        }

        return null;
    }

    public string? ReadString()
    {
        return Console.ReadLine();
    }
}
