namespace RpgSaga.Core.Abstractions;

internal interface IRandomNameGenerator
{
    (string FirstName, string LastName) Generate();
}
