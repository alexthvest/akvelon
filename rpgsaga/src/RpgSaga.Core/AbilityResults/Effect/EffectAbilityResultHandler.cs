using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.AbilityResults.Effect;

internal class EffectAbilityResultHandler : IAbilityResultHandler<EffectAbilityResult>
{
    public void Handle(EffectAbilityResult abilityResult, InternalDuelContext context)
    {
        context.ApplyEffect(abilityResult.Effect, abilityResult.Usages);
    }
}