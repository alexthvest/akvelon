using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Logic;
using RpgSaga.Core.Managment;
using RpgSaga.Core.Storages;
using Serilog;

namespace RpgSaga.Core.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRpgSagaCore(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File($"logs/rpgsaga-.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        services.AddLogging(c => c.AddSerilog());

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