using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface IAbilityDispatcher
{
    IAbilityResult Dispatch(IAbility ability, DuelContext context);
}