namespace RpgSaga.Core.Exceptions;

internal class AbilityResultHandlerNotFoundException : Exception
{
    public AbilityResultHandlerNotFoundException(Type abilityResultType)
        : base($"Ability result of type {abilityResultType} has no handlers")
    {
    }
}
