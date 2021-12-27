namespace RpgSaga.Core.Abstractions;

internal interface IRoundPairGenerator
{
    IEnumerable<IEnumerable<Hero>> Generate(IEnumerable<Hero> heroes);
}