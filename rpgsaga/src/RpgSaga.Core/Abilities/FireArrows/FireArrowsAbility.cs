using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Abilities.FireArrows;

internal class FireArrowsAbility : IAbility
{
    public int? Usages { get; } = 1;
}