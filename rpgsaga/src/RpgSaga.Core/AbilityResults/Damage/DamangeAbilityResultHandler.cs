using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.AbilityResults.Damage;

internal class DamangeAbilityResultHandler : IAbilityResultHandler<DamageAbilityResult>
{
    public void Handle(DamageAbilityResult abilityResult, InternalDuelContext context)
    {
        Console.WriteLine($"{context.Owner} deals {abilityResult.Damage} damage to {context.Target}");
        context.Target.DealDamage(abilityResult.Damage);
    }
}