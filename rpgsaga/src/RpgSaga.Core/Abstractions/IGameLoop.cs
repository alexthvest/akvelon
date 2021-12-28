using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface IGameLoop
{
    void Start(IEnumerable<Hero> heroes);
}
