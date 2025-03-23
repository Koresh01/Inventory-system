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
    [SerializeField] MenuInputHandler menuInputHandler;
    [SerializeField] ItemSpawner itemSpawner;

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

        StopHoldingHandler();
    }

    /// <summary>
    /// Делаем вывод что выбрал пользователь.
    /// </summary>
    void StopHoldingHandler()
    {
        // Направление куда указал пользователь.
        Vector2 choseDirection = menuInputHandler.chooseInput;

        // Преобразуем направление в угол.
        float angle = Mathf.Atan2(choseDirection.y, choseDirection.x) * Mathf.Rad2Deg;

        // Определяем ближайшее направление
        if (angle >= -45 && angle < 45)
        {
            // вправо
            TakeValue(ItemType.Ammo);
        }
        else if (angle >= 45 && angle < 135)
        {
            // вверх
            TakeValue(ItemType.Binoculars);
        }
        else if (angle >= -135 && angle < -45)
        {
            // вниз
            // Отмена доставания вещей из рюкзака
        }
        else
        {
            // влево
            TakeValue(ItemType.Heal);
        }
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

    /// <summary>
    /// Достаёт вещь из рюкзака.
    /// </summary>
    /// <param name="chosenType"></param>
    void TakeValue(ItemType chosenType)
    {
        if (!items.ContainsKey(chosenType))
        {
            Debug.LogError($"Ключ {chosenType} отсутвует в словаре.");
            return;
        }

        if (items[chosenType] > 0)
        {
            items[chosenType] -= 1;
            
            // Создаё объект на сцене.
            itemSpawner.SpawnItem(chosenType);
        }
        else
        {
            // Звук пустого рюкзака.
        }
    }
}
