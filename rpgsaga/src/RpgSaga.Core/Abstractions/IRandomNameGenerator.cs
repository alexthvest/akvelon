using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface IRandomNameGenerator
{
    HeroName Generate();
}
