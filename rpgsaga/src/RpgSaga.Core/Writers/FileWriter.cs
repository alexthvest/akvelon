using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Writers;

internal class FileWriter : IWriter
{
    private readonly string _path;
    private readonly bool _append;

    public FileWriter(string path, bool append = false)
    {
        _path = path;
        _append = append;
    }

    public void WriteLine(string value)
    {
        using var stream = new StreamWriter(_path, _append);
        stream.WriteLine(value);
    }
}