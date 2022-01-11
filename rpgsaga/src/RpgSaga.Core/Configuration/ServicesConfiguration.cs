using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.AbilityResults;
using RpgSaga.Core.AbilityResults.Damage;
using RpgSaga.Core.AbilityResults.Effect;
using RpgSaga.Core.AbilityResults.SkipTurn;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Logic;
using RpgSaga.Core.Managment;
using RpgSaga.Core.Models;
using RpgSaga.Core.Storages;
using Serilog;

namespace RpgSaga.Core;

internal static class ServicesConfiguration
{
    public static IServiceCollection AddRpgSagaCore(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File($"logs/rpgsaga-.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        services.AddLogging(c => c.AddSerilog());

        services.AddSingleton<GameConfiguration>();
        
        services.AddSingleton<IRoundHandler, RoundHandler>();
        services.AddSingleton<IDuelHandler, DuelHandler>();

        services.AddSingleton<IHeroStorage, HeroStorage>();
        services.AddSingleton<IAbilityStorage, AbilityStorage>();
        services.AddSingleton<IEffectStorage, EffectStorage>();

        services.AddSingleton<IAbilityDispatcher, AbilityDispatcher>();
        services.AddSingleton<IEffectDispatcher, EffectDispactcher>();

        services.AddSingleton<IRoundPairGenerator, RoundPairGenerator>();
        services.AddSingleton<IRandomNameGenerator, RandomNameGenerator>();
        services.AddSingleton<IRandomHeroGenerator, RandomHeroGenerator>();

        services.AddSingleton<ITurnManagerFactory, TurnManagerFactory>();

        services.AddSingleton<IAbilityResultHandler, AbilityResultHandler>();

        services.AddSingleton<IAbilityResultHandler<DamageAbilityResult>, DamangeAbilityResultHandler>();
        services.AddSingleton<IAbilityResultHandler<SkipTurnAbilityResult>, SkipTurnAbilityResultHandler>();
        services.AddSingleton<IAbilityResultHandler<EffectAbilityResult>, EffectAbilityResultHandler>();

        return services;
    }
}
