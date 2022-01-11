namespace RpgSaga.Core.Abstractions;

internal interface IReader
{
    string? ReadString();

    byte? ReadByte();
}