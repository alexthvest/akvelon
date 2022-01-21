using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.AbilityResults.Damage;

internal class DamageAbilityResult : IAbilityResult
{
    public DamageAbilityResult(decimal damage)
    {
        Damage = damage;
    }

    public decimal Damage { get; }
}
