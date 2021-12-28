using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

internal interface IDuelHandler
{
    GameDuel Handle(Hero[] heroes);
}
