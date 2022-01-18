using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

public interface IEffectHandler
{
    IAbilityResult Handle(IEffect effect, DuelContext context);
}

public interface IEffectHandler<TEffect> : IEffectHandler
    where TEffect : IEffect, new()
{
    IAbilityResult Handle(TEffect effect, DuelContext context);

    IAbilityResult IEffectHandler.Handle(IEffect effect, DuelContext context)
    {
        return Handle((TEffect)effect, context);
    }
}
