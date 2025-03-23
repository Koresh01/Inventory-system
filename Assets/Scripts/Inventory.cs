using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер рюкзака.
/// </summary>
public class Inventory : MonoBehaviour
{
    private Dictionary<ItemType, int> items = new Dictionary<ItemType, int>();

    public void AddItem(ItemType itemType)
    {
        // Проверка, существует ли уже такой предмет в словаре
        if (items.ContainsKey(itemType))
        {
            // Увеличиваем количество предметов этого типа
            items[itemType] += 1;
        }
        else
        {
            // Если такого предмета нет, добавляем его с количеством 1
            items.Add(itemType, 1);
        }

        // Debug.Log($"Добавлен предмет: {itemType}, Количество: {items[itemType]}");
    }

    [ContextMenu("Напечатать все элементы")]
    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Debug.Log($"тип: {item.Key} кол-во: {item.Value}");
        }
    }

    // Срабатывает при столкновении с другим коллайдером
    private void OnCollisionEnter(Collision collision)
    {
        // Проверка, если объект, с которым произошел контакт, имеет компонент IItem
        IItem item = collision.gameObject.GetComponent<IItem>();
        if (item != null)
        {
            ItemType itemType = item.ItemType;
            // Добавление предмета в инвентарь
            AddItem(itemType);
            // Удаляем объект
            Destroy(collision.gameObject);  // удаляет и ключ в словаре, а ненадо!
        }
    }
}
