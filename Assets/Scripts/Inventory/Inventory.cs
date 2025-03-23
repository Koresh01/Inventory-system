using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������� �������.
/// </summary>
public class Inventory : MonoBehaviour, IHoldable
{
    public Dictionary<ItemType, int> items = new Dictionary<ItemType, int>();

    [Header("������ �� �����������:")]
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] GameObject inventoryPanel;

    private void Awake()
    {
        inventoryPanel.SetActive(false);
    }

    public void StartHolding()
    {
        inventoryPanel.SetActive(true);
        playerInputHandler.isPaused = true;
    }

    public void StopHolding()
    {
        inventoryPanel.SetActive(false);
        playerInputHandler.isPaused = false;
    }

    public void AddItem(ItemType itemType)
    {
        if (items.ContainsKey(itemType))
        {
            items[itemType] += 1;
        }
        else
        {
            items.Add(itemType, 1);
        }
    }

    [ContextMenu("���������� ��� ��������")]
    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Debug.Log($"���: {item.Key} ���-��: {item.Value}");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Item item = collision.gameObject.GetComponent<Item>();
        if (item != null)
        {
            AddItem(item.itemType);
            Destroy(collision.gameObject);
        }
    }
}
