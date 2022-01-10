using RpgSaga.Core.Abstractions;

namespace RpgSaga.Core.Effects.Fire;

internal class FireEffect : IEffect
{
    public decimal Damage { get; } = 2;
}
