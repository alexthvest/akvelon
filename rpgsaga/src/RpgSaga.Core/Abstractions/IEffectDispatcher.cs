using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface IEffectDispatcher
{
    IAbilityResult Dispatch(IEffect effect, DuelContext context);
}