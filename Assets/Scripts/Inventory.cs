using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������� �������.
/// </summary>
public class Inventory : MonoBehaviour
{
    private Dictionary<ItemType, int> items = new Dictionary<ItemType, int>();

    public void AddItem(ItemType itemType)
    {
        // ��������, ���������� �� ��� ����� ������� � �������
        if (items.ContainsKey(itemType))
        {
            // ����������� ���������� ��������� ����� ����
            items[itemType] += 1;
        }
        else
        {
            // ���� ������ �������� ���, ��������� ��� � ����������� 1
            items.Add(itemType, 1);
        }

        // Debug.Log($"�������� �������: {itemType}, ����������: {items[itemType]}");
    }

    [ContextMenu("���������� ��� ��������")]
    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Debug.Log($"���: {item.Key} ���-��: {item.Value}");
        }
    }

    // ����������� ��� ������������ � ������ �����������
    private void OnCollisionEnter(Collision collision)
    {
        // ��������, ���� ������, � ������� ��������� �������, ����� ��������� IItem
        IItem item = collision.gameObject.GetComponent<IItem>();
        if (item != null)
        {
            ItemType itemType = item.ItemType;
            // ���������� �������� � ���������
            AddItem(itemType);
            // ������� ������
            Destroy(collision.gameObject);  // ������� � ���� � �������, � ������!
        }
    }
}
