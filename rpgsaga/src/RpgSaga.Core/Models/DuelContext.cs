using System.Collections.Immutable;

namespace RpgSaga.Core.Models;

public class DuelContext
{
    public DuelContext(Hero owner, Hero target, IEnumerable<DuelEffect> effects)
    {
        Owner = owner;
        Target = target;
        Effects = ImmutableArray.CreateRange(effects);
    }

    public Hero Owner { get; }

    public Hero Target { get; }

    public ImmutableArray<DuelEffect> Effects { get; }
}
