using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.AbilityResults;

internal class AbilityResultHandler : IAbilityResultHandler
{
    private readonly IServiceProvider _serviceProvider;

    public AbilityResultHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Handle(IAbilityResult abilityResult, InternalDuelContext context)
    {
        var abilityResultType = abilityResult.GetType();
        var abilityResultHandlerType = typeof(IAbilityResultHandler<>).MakeGenericType(abilityResultType);

        if (_serviceProvider.GetService(abilityResultHandlerType) is not IAbilityResultHandler abilityResultHandler)
        {
            throw new Exception($"Ability result of type {abilityResultType} has no handlers");
        }

        abilityResultHandler.Handle(abilityResult, context);
    }
}