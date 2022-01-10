using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

public interface IAbilityDispatcher
{
    IAbilityResult Dispatch(Type abilityType, DuelContext context);
}