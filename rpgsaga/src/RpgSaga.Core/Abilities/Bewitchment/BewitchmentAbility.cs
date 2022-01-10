using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Abilities.Bewitchment;

internal class BewitchmentAbility : IAbility
{
    public int? Usages { get; } = default;
}