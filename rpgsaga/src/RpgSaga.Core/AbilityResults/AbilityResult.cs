using RpgSaga.Core.AbilityResults.Damage;
using RpgSaga.Core.AbilityResults.Effect;
using RpgSaga.Core.AbilityResults.SkipTurn;
using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.AbilityResults;

internal static class AbilityResult
{
    public static DamageAbilityResult FromDamage(decimal damage)
    {
        return new DamageAbilityResult(damage);
    }

    public static SkipTurnAbilityResult SkipTurn()
    {
        return new SkipTurnAbilityResult();
    }

    public static EffectAbilityResult FromEffect(IEffect effect, int? usages = default)
    {
        return new EffectAbilityResult(effect, usages);
    }

    public static EffectAbilityResult FromEffect<TEffect>(int? usages = default)
        where TEffect : IEffect, new()
    {
        return FromEffect(new TEffect(), usages);
    }
}
