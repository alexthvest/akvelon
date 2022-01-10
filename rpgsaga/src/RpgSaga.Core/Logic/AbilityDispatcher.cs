using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Logic;

internal class AbilityDispatcher : IAbilityDispatcher
{
    private readonly IAbilityStorage _abilityStorage;

    public AbilityDispatcher(IAbilityStorage abilityStorage)
    {
        _abilityStorage = abilityStorage;
    }

    public IAbilityResult Dispatch(Type abilityType, DuelContext context)
    {
        var abilityInstance = Activator.CreateInstance(abilityType);

        if (abilityInstance is not IAbility { } ability)
        {
            throw new Exception($"Invalid ability type: {abilityType}");
        }

        if (_abilityStorage.GetAbilityHandler(abilityType) is not { } abilityHandler)
        {
            throw new Exception($"Ability of type {abilityType} has no handlers");
        }

        return abilityHandler.Handle(ability, context);
    }
}
