using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Readers;

internal class CommandLineArgsReader : IReader
{
    private readonly string[] _args;
    private readonly string _option;

    public CommandLineArgsReader(string[] args, string option)
    {
        _args = args;
        _option = option;
    }

    public byte? ReadByte()
    {
        var optionValue = ReadString();

        if (byte.TryParse(optionValue, out var value))
        {
            return value;
        }

        return null;
    }

    public string? ReadString()
    {
        var optionIndex = Array.IndexOf(_args, _option);

        if (optionIndex == -1 || _args.Length <= optionIndex + 1)
        {
            return null;
        }

        return _args[optionIndex + 1];
    }
}
