﻿namespace OnlineShop.Domain.Entities;

public abstract class Entity<T>
    where T : struct
{
    public T Id { get; init; }
}