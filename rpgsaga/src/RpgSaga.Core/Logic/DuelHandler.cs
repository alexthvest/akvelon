using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Extensions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Logic;

internal class DuelHandler : IDuelHandler
{
    private readonly ITurnManagerFactory _turnManagerFactory;
    private readonly IAbilityDispatcher _abilityDispatcher;

    public DuelHandler(ITurnManagerFactory turnManagerFactory, IAbilityDispatcher abilityDispatcher)
    {
        _turnManagerFactory = turnManagerFactory;
        _abilityDispatcher = abilityDispatcher;
    }

    public GameDuel Handle(Hero[] heroes)
    {
        if (heroes.Length == 0)
        {
            throw new ArgumentOutOfRangeException("Pair must consists of one or two heroes");
        }

        if (heroes.Length == 1)
        {
            return new GameDuel(heroes, heroes[0]);
        }

        Console.WriteLine($"{heroes[0]} vs {heroes[1]}");

        var heroStates = heroes.Select(h => new HeroState(h)).ToArray();
        var turnManager = _turnManagerFactory.Create(heroStates);

        while (true)
        {
            var owner = turnManager.Owner;
            var target = turnManager.Target;

            var context = new DuelContext(owner, target);

            if (owner.Hero.Abilities.Count > 0)
            {
                var abilityType = owner.Hero.Abilities.GetRandomValue();
                _abilityDispatcher.Dispatch(abilityType, context);

                Console.WriteLine($"{owner} uses {abilityType}");
            }
            else
            {
                Console.WriteLine($"{owner} deals {owner.Hero.Attack} damage to {target}");
                target.DealDamange(owner.Hero.Attack);
            }

            if (target.IsDead)
            {
                Console.WriteLine($"{target} has died out");
                return new GameDuel(heroes, owner);
            }

            turnManager.NextTurn();
        }
    }
}
