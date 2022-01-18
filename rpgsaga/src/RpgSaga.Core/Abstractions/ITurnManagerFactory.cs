using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface ITurnManagerFactory
{
    ITurnManager Create(HeroState[] heroStates);
}
