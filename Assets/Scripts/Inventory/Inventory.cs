using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер рюкзака.
/// </summary>
public class Inventory : MonoBehaviour, IHoldable
{
    public Dictionary<ItemType, int> items = new Dictionary<ItemType, int>();

    [Header("Ссылки на зависимости:")]
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

    [ContextMenu("Напечатать все элементы")]
    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Debug.Log($"тип: {item.Key} кол-во: {item.Value}");
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
