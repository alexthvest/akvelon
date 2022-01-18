using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface IAbilityResultHandler
{
    void Handle(IAbilityResult abilityResult, InternalDuelContext context);
}

internal interface IAbilityResultHandler<TAbilityResult> : IAbilityResultHandler
    where TAbilityResult : IAbilityResult
{
    void Handle(TAbilityResult abilityResult, InternalDuelContext context);

    void IAbilityResultHandler.Handle(IAbilityResult abilityResult, InternalDuelContext context)
    {
        Handle((TAbilityResult)abilityResult, context);
    }
}