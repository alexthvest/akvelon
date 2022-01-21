namespace RpgSaga.Core.Exceptions;

internal class AbilityHandlerNotFoundException : Exception
{
    public AbilityHandlerNotFoundException(Type abilityType)
        : base($"Ability of type {abilityType} has no handlers")
    {
    }
}
