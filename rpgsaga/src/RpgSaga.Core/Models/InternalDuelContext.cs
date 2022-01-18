using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Models;

internal record InternalDuelContext(IAttackOwner Owner, HeroState Target)
{
    private readonly List<DuelEffect> _effects = new ();

    public IReadOnlyCollection<DuelEffect> Effects => _effects
        .Where(duelEffect => duelEffect.Usages > 0 || duelEffect.Infinite)
        .ToArray();

    public bool NextTurnRequested { get; private set; }

    public void ApplyEffect(IEffect effect, int? usages = default)
    {
        if (Owner is not HeroState owner)
        {
            return;
        }

        var duelEffect = new DuelEffect(effect, owner, Target, usages);
        _effects.Add(duelEffect);
    }

    public void RequestNextTurn() => NextTurnRequested = true;

    public void CancelNextTurnRequest() => NextTurnRequested = false;
}