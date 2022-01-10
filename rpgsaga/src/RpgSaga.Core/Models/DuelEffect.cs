using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Models;

public class DuelEffect
{
    public DuelEffect(IEffect effect, Hero target, int? usages = default)
    {
        Effect = effect;
        Target = target;
        Usages = usages;
    }

    public IEffect Effect { get; }

    public Hero Target { get; }

    public int? Usages { get; set; }

    public bool Infinite => Usages is null;
}
