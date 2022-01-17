using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Logic;
using RpgSaga.Core.Managment;
using RpgSaga.Core.Storages;
using RpgSaga.Core.Writers;
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

        services.AddSingleton<IWriter, ConsoleWriter>();

        services.AddSingleton<IRoundHandler, RoundHandler>();
        services.AddSingleton<IDuelHandler, DuelHandler>();

        services.AddSingleton<IHeroStorage, HeroStorage>();

        services.AddSingleton<IRoundPairGenerator, RoundPairGenerator>();
        services.AddSingleton<IRandomNameGenerator, RandomNameGenerator>();
        services.AddSingleton<IHeroGenerator, HeroGenerator>();

        return services;
    }
}
