using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface IHeroGenerator
{
    Hero Generate(string heroType, HeroName name);
}
