using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.AbilityResults.Damage;

internal class DamangeAbilityResultHandler : IAbilityResultHandler<DamageAbilityResult>
{
    private readonly IWriter _writer;

    public DamangeAbilityResultHandler(IWriter writer)
    {
        _writer = writer;
    }

    public void Handle(DamageAbilityResult abilityResult, InternalDuelContext context)
    {
        var owner = context.Owner switch
        {
            IEffect effect => $"<{effect.GetType().Name.Replace("Effect", string.Empty)}>",
            HeroState heroState => heroState.ToString(),

            _ => throw new Exception($"Unknown attack owner: {context.Owner}")
        };

        _writer.WriteLine($"{owner} deals {abilityResult.Damage} damage to {context.Target}");
        
        context.Target.DealDamage(abilityResult.Damage);
    }
}