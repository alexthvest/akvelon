using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Storages;

internal class EffectStorage : IEffectStorage
{
    private readonly Dictionary<Type, IEffectHandler> _handlers = new ();
    private readonly IServiceProvider _serviceProvider;

    public EffectStorage(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Add<TEffect, TEffectHandler>()
        where TEffect : IEffect, new()
        where TEffectHandler : IEffectHandler<TEffect>
    {
        _handlers[typeof(TEffect)] = ActivatorUtilities.CreateInstance<TEffectHandler>(_serviceProvider);
    }

    public IEffectHandler? GetEffectHandler(Type effectType)
    {
        if (_handlers.TryGetValue(effectType, out var effectHandler))
        {
            return effectHandler;
        }

        return null;
    }
}
