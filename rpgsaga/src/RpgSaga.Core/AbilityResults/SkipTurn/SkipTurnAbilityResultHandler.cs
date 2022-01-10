using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.AbilityResults.SkipTurn;

internal class SkipTurnAbilityResultHandler : IAbilityResultHandler<SkipTurnAbilityResult>
{
    public void Handle(SkipTurnAbilityResult abilityResult, InternalDuelContext context)
    {
        Console.WriteLine($"{context.Target} misses turn");
        context.RequestNextTurn();
    }
}