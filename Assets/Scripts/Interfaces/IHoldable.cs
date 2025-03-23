using UnityEngine;

/// <summary>
/// Захватываемый объект.
/// </summary>
public interface IHoldable
{
    /// <summary>
    /// Начать удержание
    /// </summary>
    void StartHolding();
    /// <summary>
    /// Закончить удержание.
    /// </summary>
    void StopHolding();
}
