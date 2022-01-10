using RpgSaga.Core.AbilityResults;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abilities.Nemesis;

internal class NemesisAbilityHandler : IAbilityHandler<NemesisAbility>
{
    public IAbilityResult Handle(NemesisAbility ability, DuelContext context)
    {
        return AbilityResult.FromDamage(context.Owner.Attack * 1.3M);
    }
}