using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface IRandomHeroGenerator
{
    Hero Generate();
}
