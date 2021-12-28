using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

public delegate Hero HeroFactory(string firstName, string lastName, double health, double attack);
