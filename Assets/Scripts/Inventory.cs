using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер рюкзака.
/// </summary>
public class Inventory : MonoBehaviour
{
    private List<IItem> items = new List<IItem>();

    public void AddItem(IItem item)
    {
        items.Add(item);
        Debug.Log($"Добавлен предмет: {item.Name}, Вес: {item.Weight}");
    }
}
