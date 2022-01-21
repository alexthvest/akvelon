namespace RpgSaga.Core.Models;

internal class HeroDto
{
    public HeroDto(string type, HeroName name)
    {
        Type = type;
        Name = name;
    }

    public string Type { get; }

    public HeroName Name { get; }
}
