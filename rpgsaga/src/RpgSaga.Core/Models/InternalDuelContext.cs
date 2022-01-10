using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Models;

internal record InternalDuelContext(HeroState Owner, HeroState Target)
{
    private readonly List<DuelEffect> _effects = new ();

    public IReadOnlyCollection<DuelEffect> Effects => _effects;

    public bool NextTurnRequested { get; set; }

    public void ApplyEffect(IEffect effect, int? usages = default)
    {
        var duelEffect = new DuelEffect(effect, Target, usages);
        _effects.Add(duelEffect);
    }

    public void RemoveEffect(DuelEffect effect)
    {
        _effects.Remove(effect);
    }

    public void RequestNextTurn()
    {
        NextTurnRequested = true;
    }
}