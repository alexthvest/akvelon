using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Exceptions;
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
            throw new AbilityHandlerNotFoundException(abilityType);
        }

        return abilityHandler.Handle(ability, context);
    }
}
