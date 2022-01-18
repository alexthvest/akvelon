using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Models;

internal record DuelAbility(IAbility Ability)
{
    public int? Usages { get; private set; } = Ability.Usages;

    public bool Infinite => Usages is null;

    public void RegisterUse() => Usages--;
}
