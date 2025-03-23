using UnityEngine;

/// <summary>
/// Класс для спавна предметов в мире. Предметы спавнятся в указанной позиции без применения физики.
/// </summary>
public class ItemSpawner : MonoBehaviour
{
    [Header("Префабы для разных типов предметов")]
    [SerializeField] private GameObject healPrefab;        // Префаб для предмета восстановления здоровья
    [SerializeField] private GameObject ammoPrefab;        // Префаб для патронов
    [SerializeField] private GameObject binocularsPrefab;  // Префаб для бинокля

    /// <summary>
    /// Метод для спавна предмета в позиции спавнера. 
    /// Предмет создается без применения физики.
    /// </summary>
    /// <param name="itemType">Тип предмета, который нужно создать</param>
    public void SpawnItem(ItemType itemType)
    {
        // Получаем соответствующий префаб в зависимости от типа предмета
        GameObject itemPrefab = GetItemPrefab(itemType);

        // Спавним предмет в позиции спавнера без углов поворота
        Instantiate(itemPrefab, transform.position, Quaternion.identity);
    }

    /// <summary>
    /// Метод для получения префаба в зависимости от типа предмета.
    /// </summary>
    /// <param name="itemType">Тип предмета</param>
    /// <returns>Префаб предмета</returns>
    private GameObject GetItemPrefab(ItemType itemType)
    {
        // Возвращаем нужный префаб в зависимости от типа
        switch (itemType)
        {
            case ItemType.Heal:
                return healPrefab;
            case ItemType.Ammo:
                return ammoPrefab;
            case ItemType.Binoculars:
                return binocularsPrefab;
            default:
                return null; // В случае неизвестного типа предмета
        }
    }
}
