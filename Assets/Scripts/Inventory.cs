using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������� �������.
/// </summary>
public class Inventory : MonoBehaviour
{
    private List<IItem> items = new List<IItem>();

    public void AddItem(IItem item)
    {
        items.Add(item);
        Debug.Log($"�������� �������: {item.Name}, ���: {item.Weight}");
    }
}
