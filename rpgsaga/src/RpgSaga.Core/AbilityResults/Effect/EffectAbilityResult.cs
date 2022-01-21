using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.AbilityResults.Effect;

internal class EffectAbilityResult : IAbilityResult
{
    public EffectAbilityResult(IEffect effect, int? usages = default)
    {
        Effect = effect;
        Usages = usages;
    }

    public IEffect Effect { get; }

    public int? Usages { get; }

    public bool Infinite => Usages is null;
}
