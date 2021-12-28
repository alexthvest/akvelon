using Microsoft.Extensions.DependencyInjection;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Logic;
using RpgSaga.Core.Managment;

namespace RpgSaga.Core.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRpgSagaCore(this IServiceCollection services)
    {
        services.AddSingleton<IRoundHandler, RoundHandler>();
        services.AddSingleton<IDuelHandler, DuelHandler>();
        services.AddSingleton<IRoundPairGenerator, RoundPairGenerator>();

        return services;
    }
}
