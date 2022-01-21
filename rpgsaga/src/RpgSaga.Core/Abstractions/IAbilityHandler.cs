using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

public interface IAbilityHandler
{
    IAbilityResult Handle(IAbility ability, DuelContext context);
}

public interface IAbilityHandler<TAbility> : IAbilityHandler
    where TAbility : IAbility, new()
{
    IAbilityResult Handle(TAbility ability, DuelContext context);

    IAbilityResult IAbilityHandler.Handle(IAbility ability, DuelContext context)
    {
        return Handle((TAbility)ability, context);
    }
}
