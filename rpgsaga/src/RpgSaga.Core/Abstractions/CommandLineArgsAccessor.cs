namespace RpgSaga.Core.Abstractions;

internal class CommandLineArgsAccessor
{
    public CommandLineArgsAccessor(string[] args)
    {
        Args = args;
    }

    public string[] Args { get; }
}