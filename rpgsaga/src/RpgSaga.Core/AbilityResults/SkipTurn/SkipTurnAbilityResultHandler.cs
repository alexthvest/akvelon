using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.AbilityResults.SkipTurn;

internal class SkipTurnAbilityResultHandler : IAbilityResultHandler<SkipTurnAbilityResult>
{
    private readonly IWriter _writer;

    public SkipTurnAbilityResultHandler(IWriter writer)
    {
        _writer = writer;
    }

    public void Handle(SkipTurnAbilityResult abilityResult, InternalDuelContext context)
    {
        _writer.WriteLine($"{context.Target} misses turn");
        
        context.RequestNextTurn();
    }
}