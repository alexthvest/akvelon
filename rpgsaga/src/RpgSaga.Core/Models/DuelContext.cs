namespace RpgSaga.Core.Models;

public class DuelContext
{
    public DuelContext(Hero owner, Hero target)
    {
        Owner = owner;
        Target = target;
    }

    public Hero Owner { get; }

    public Hero Target { get; }
}
