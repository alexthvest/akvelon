namespace RpgSaga.Core.Abstractions;

public interface IEffectStorage
{
    void Add<TEffect, TEffectHandler>()
        where TEffect : IEffect, new()
        where TEffectHandler : IEffectHandler<TEffect>;

    IEffectHandler? GetEffectHandler(Type effectType);
}
