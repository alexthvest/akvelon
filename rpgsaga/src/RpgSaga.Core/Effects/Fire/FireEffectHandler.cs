using RpgSaga.Core.AbilityResults;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Effects.Fire;

internal class FireEffectHandler : IEffectHandler<FireEffect>
{
    public IAbilityResult Handle(FireEffect effect, DuelContext context)
    {
        Console.WriteLine($"<Fire> deals {effect.Damage} to {context.Target}");
        return AbilityResult.FromDamage(effect.Damage);
    }
}