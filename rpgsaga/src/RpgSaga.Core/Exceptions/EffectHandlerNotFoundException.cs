namespace RpgSaga.Core.Exceptions;

internal class EffectHandlerNotFoundException : Exception
{
    public EffectHandlerNotFoundException(Type effectType)
        : base($"Effect of type {effectType} has no handlers")
    {
    }
}
