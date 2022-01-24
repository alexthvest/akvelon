namespace RpgSaga.Core.Abstractions;

public interface IAbilityStorage
{
    void Add<TAbility, TAbilityHandler>()
        where TAbility : IAbility, new()
        where TAbilityHandler : IAbilityHandler<TAbility>;

    IAbilityHandler? GetAbilityHandler(Type abilityType);
}
