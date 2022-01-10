using RpgSaga.Core.AbilityResults;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Extensions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Logic;

internal class DuelHandler : IDuelHandler
{
    private readonly ITurnManagerFactory _turnManagerFactory;
    private readonly IAbilityDispatcher _abilityDispatcher;
    private readonly IAbilityResultHandler _abilityResultHandler;

    public DuelHandler(ITurnManagerFactory turnManagerFactory, IAbilityDispatcher abilityDispatcher, IAbilityResultHandler abilityResultHandler)
    {
        _turnManagerFactory = turnManagerFactory;
        _abilityDispatcher = abilityDispatcher;
        _abilityResultHandler = abilityResultHandler;
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

        var heroStates = heroes.Select(hero => new HeroState(hero)).ToArray();
        var turnManager = _turnManagerFactory.Create(heroStates);

        var internalContext = new InternalDuelContext(turnManager.Owner, turnManager.Target);

        while (true)
        {
            var owner = turnManager.Owner;
            var target = turnManager.Target;

            internalContext = internalContext with { Owner = owner, Target = target };

            foreach (var duelEffect in internalContext.Effects.ToList())
            {
                if (duelEffect.Usages == 0)
                {
                    internalContext.RemoveEffect(duelEffect);
                    continue;
                }

                Console.WriteLine(duelEffect.Effect.GetType().Name);
                duelEffect.Usages--;
            }

            IAbilityResult abilityResult = AbilityResult.FromDamage(owner.Hero.Attack);

            // Dispatch ability with 35% chance
            if (owner.Hero.Abilities.Count > 0 && Random.Shared.Next(0, 100) < 35)
            {
                var context = new DuelContext(owner, target, internalContext.Effects);
                var abilityType = owner.Hero.Abilities.GetRandomValue();

                abilityResult = _abilityDispatcher.Dispatch(abilityType, context);

                Console.WriteLine($"{owner} uses {abilityType.Name.Replace("Ability", string.Empty)}");
            }

            _abilityResultHandler.Handle(abilityResult, internalContext);

            if (target.IsDead)
            {
                Console.WriteLine($"{target} has died out");
                return new GameDuel(heroes, owner);
            }

            if (internalContext.NextTurnRequested)
            {
                turnManager.NextTurn();
                internalContext.NextTurnRequested = false;
            }

            turnManager.NextTurn();
        }
    }
}