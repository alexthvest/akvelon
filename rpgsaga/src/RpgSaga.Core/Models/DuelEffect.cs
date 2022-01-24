using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Models;

public record DuelEffect(IEffect Effect, Hero Owner, Hero Target, int? Usages = default)
{
    public int? Usages { get; private set; } = Usages;

    public bool Infinite => Usages is null;

    public void RegisterUse() => Usages--;
}
