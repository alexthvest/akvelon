using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Logic;

internal class EffectDispactcher : IEffectDispatcher
{
    private readonly IEffectStorage _effectStorage;

    public EffectDispactcher(IEffectStorage effectStorage)
    {
        _effectStorage = effectStorage;
    }

    public IAbilityResult Dispatch(IEffect effect, DuelContext context)
    {
        var effectType = effect.GetType();
        
        if (_effectStorage.GetEffectHandler(effectType) is not { } effectHandler)
        {
            throw new Exception($"Effect of type {effectType} has no handlers");
        }

        return effectHandler.Handle(effect, context);
    }
}
