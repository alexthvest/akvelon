namespace OnlineShop.Application.Interfaces;

/// <summary>
/// Represents an interface to data transfer objects.
/// </summary>
/// <typeparam name="T">Entity.</typeparam>
public interface IDtoMapper<T>
{
    /// <summary>Converts to model.</summary>
    /// <returns>Model with type T.</returns>
    T ToModel();
}