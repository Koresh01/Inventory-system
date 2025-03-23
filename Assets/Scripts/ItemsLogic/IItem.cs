using UnityEngine;

public interface IItem
{
    Sprite Icon { get; }
    int Weight { get; }
    string Name { get; }
}
