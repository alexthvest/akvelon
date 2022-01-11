using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Readers;

internal class ConsoleReader : IReader
{
    private readonly string? _promptMessage;

    public ConsoleReader(string? promptMessage = default)
    {
        _promptMessage = promptMessage;
    }

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
        if (_promptMessage is not null)
        {
            Console.Write(_promptMessage);
        }

        return Console.ReadLine();
    }
}
