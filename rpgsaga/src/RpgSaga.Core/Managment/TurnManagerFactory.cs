using RpgSaga.Core.Abstractions;
using RpgSaga.Core.Models;

namespace RpgSaga.Core.Managment;

internal class TurnManagerFactory : ITurnManagerFactory
{
    public ITurnManager Create(HeroState[] heroStates)
    {
        return new TurnManager(heroStates);
    }
}