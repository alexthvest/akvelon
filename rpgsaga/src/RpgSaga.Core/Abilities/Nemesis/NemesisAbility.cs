using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Abilities.Nemesis;

internal class NemesisAbility : IAbility
{
    public int? Usages { get; } = default;
}