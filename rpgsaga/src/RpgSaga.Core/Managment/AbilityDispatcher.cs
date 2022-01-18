using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Managment;

internal class AbilityDispatcher : IAbilityDispatcher
{
    private readonly IAbilityStorage _abilityStorage;

    public AbilityDispatcher(IAbilityStorage abilityStorage)
    {
        _abilityStorage = abilityStorage;
    }

    public IAbilityResult Dispatch(IAbility ability, DuelContext context)
    {
        var abilityType = ability.GetType();

        if (_abilityStorage.GetAbilityHandler(abilityType) is not { } abilityHandler)
        {
            throw new Exception($"Ability of type {abilityType} has no handlers");
        }

        return abilityHandler.Handle(ability, context);
    }
}
