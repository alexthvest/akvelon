using RpgSaga.Core.AbilityResults;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Effects.Fire;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abilities.FireArrows;

internal class FireArrowsAbilityHandler : IAbilityHandler<FireArrowsAbility>
{
    public IAbilityResult Handle(FireArrowsAbility ability, DuelContext context)
    {
        return AbilityResult.FromEffect<FireEffect>();
    }
}