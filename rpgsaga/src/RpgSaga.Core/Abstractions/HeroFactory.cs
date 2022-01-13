using RpgSaga.Core.Models;

namespace RpgSaga.Core.Abstractions;

public delegate Hero HeroFactory(HeroName name, decimal health, decimal attack);
