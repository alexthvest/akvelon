using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Storages;

internal class AbilityStorage : IAbilityStorage
{
    private readonly Dictionary<Type, IAbilityHandler> _handlers = new ();
    private readonly IServiceProvider _serviceProvider;

    public AbilityStorage(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Add<TAbility, TAbilityHandler>()
        where TAbility : IAbility, new()
        where TAbilityHandler : IAbilityHandler<TAbility>
    {
        _handlers[typeof(TAbility)] = ActivatorUtilities.CreateInstance<TAbilityHandler>(_serviceProvider);
    }

    public IAbilityHandler? GetAbilityHandler(Type abilityType)
    {
        if (_handlers.TryGetValue(abilityType, out var abilityHandler))
        {
            return abilityHandler;
        }

        return null;
    }
}