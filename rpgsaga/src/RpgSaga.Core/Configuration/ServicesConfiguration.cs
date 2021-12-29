using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Logic;
using RpgSaga.Core.Managment;
using RpgSaga.Core.Storages;

namespace RpgSaga.Core;

internal static class ServicesConfiguration
{
    public static IServiceCollection AddRpgSagaCore(this IServiceCollection services)
    {
        services.AddSingleton<GameConfiguration>();

        services.AddSingleton<IGameLoop, GameLoop>();
        services.AddSingleton<IRoundHandler, RoundHandler>();
        services.AddSingleton<IDuelHandler, DuelHandler>();

        services.AddSingleton<IHeroStorage, HeroStorage>();

        services.AddSingleton<IRoundPairGenerator, RoundPairGenerator>();
        services.AddSingleton<IRandomNameGenerator, RandomNameGenerator>();
        services.AddSingleton<IRandomHeroGenerator, RandomHeroGenerator>();
        
        return services;
    }
}
