using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Exceptions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Managment;

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
            throw new EffectHandlerNotFoundException(effectType);
        }

        return effectHandler.Handle(effect, context);
    }
}
