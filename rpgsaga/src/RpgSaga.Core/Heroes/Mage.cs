﻿using RpgSaga.Core.Abilities.Bewitchment;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Heroes;

internal sealed class Mage : Hero
{
    public Mage(HeroName name, decimal health, decimal attack)
        : base(name, health, attack)
    {
        AddAbility<BewitchmentAbility>();
    }

    public static Mage Create(HeroName name, decimal health, decimal attack)
    {
        return new Mage(name, health, attack);
    }
}
