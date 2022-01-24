﻿using RpgSaga.Core.AbilityResults;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abilities.Bewitchment;

internal class BewitchmentAbilityHandler : IAbilityHandler<BewitchmentAbility>
{
    public IAbilityResult Handle(BewitchmentAbility ability, DuelContext context)
    {
        return AbilityResult.SkipTurn();
    }
}