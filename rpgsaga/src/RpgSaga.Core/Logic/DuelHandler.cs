using Microsoft.Extensions.Logging;
using RpgSaga.Core.AbilityResults;
using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Extensions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Logic;

internal class DuelHandler : IDuelHandler
{
    private readonly ILogger<DuelHandler> _logger;
    private readonly IWriter _writer;
    private readonly ITurnManagerFactory _turnManagerFactory;
    private readonly IAbilityDispatcher _abilityDispatcher;
    private readonly IAbilityResultHandler _abilityResultHandler;
    private readonly IEffectDispatcher _effectDispatcher;

    public DuelHandler(
        ILogger<DuelHandler> logger,
        IWriter writer,
        ITurnManagerFactory turnManagerFactory,
        IAbilityDispatcher abilityDispatcher,
        IEffectDispatcher effectDispatcher,
        IAbilityResultHandler abilityResultHandler)
    {
        _logger = logger;
        _writer = writer;
        _turnManagerFactory = turnManagerFactory;
        _abilityDispatcher = abilityDispatcher;
        _effectDispatcher = effectDispatcher;
        _abilityResultHandler = abilityResultHandler;
    }

    /// <summary>
    /// Handles battle logic between two heroes.
    /// </summary>
    /// <param name="heroes">Pair of heroes.</param>
    /// <returns>Result of battle containing heroes and winner of the duel.</returns>
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

        _writer.WriteLine($">>> {heroes[0]} vs {heroes[1]}");
        _logger.LogInformation("Duel between two heroes begin: {@Heroes}", heroes);

        var heroStates = heroes.Select(hero => new HeroState(hero)).ToArray();
        var turnManager = _turnManagerFactory.Create(heroStates);

        var internalContext = new InternalDuelContext(turnManager.Owner, turnManager.Target);

        while (true)
        {
            var owner = turnManager.Owner;
            var target = turnManager.Target;

            internalContext = internalContext with { Owner = owner, Target = target };

            ApplyEffects(heroStates, internalContext);

            // Default action is basic hero attack
            IAbilityResult abilityResult = AbilityResult.FromDamage(owner.Hero.Attack);

            // Dispatch ability with 35% chance
            if (owner.Abilities.Any() && Random.Shared.Next(0, 100) <= 35)
            {
                var duelAbility = owner.Abilities.GetRandomValue();

                var ability = duelAbility.Ability;
                var abilityName = ability.GetType().Name.Replace("Ability", string.Empty);

                var context = new DuelContext(owner, target, internalContext.Effects);

                abilityResult = _abilityDispatcher.Dispatch(ability, context);
                duelAbility.RegisterUse();

                _writer.WriteLine($"{owner} uses {abilityName}");
                _logger.LogInformation("Ability used: {@Owner} {@Ability}", owner, ability);
            }

            _abilityResultHandler.Handle(abilityResult, internalContext);

            if (target.IsDead)
            {
                _writer.WriteLine($"{target} has died out");
                _logger.LogInformation("Hero has died out: {@Hero}", target);

                return new GameDuel(heroes, owner);
            }

            if (internalContext.NextTurnRequested)
            {
                turnManager.NextTurn();
                internalContext.CancelNextTurnRequest();
            }

            turnManager.NextTurn();
        }
    }

    private void ApplyEffects(HeroState[] heroStates, InternalDuelContext internalContext)
    {
        foreach (var duelEffect in internalContext.Effects)
        {
            var (_, owner, target, _) = duelEffect;

            var ownerState = heroStates.First(s => s.Hero == owner);
            var targetState = heroStates.First(s => s.Hero == target);

            var context = new DuelContext(owner, target, internalContext.Effects);
            var effectInternalContext = internalContext with { Owner = ownerState, Target = targetState };

            var effectResult = _effectDispatcher.Dispatch(duelEffect.Effect, context);

            _abilityResultHandler.Handle(effectResult, effectInternalContext);
            duelEffect.RegisterUse();
        }
    }
}
