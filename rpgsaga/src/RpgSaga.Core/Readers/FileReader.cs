using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Readers;

internal class FileReader : IReader
{
    private readonly string _path;

    public FileReader(string path)
    {
        _path = path;
    }

    public byte? ReadByte()
    {
        throw new NotImplementedException();
    }

    public string? ReadString()
    {
        return File.ReadAllText(_path);
    }
}
