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
    /// ������ ����� ��� ������ ������������.
    /// </summary>
    void StopHoldingHandler()
    {
        // ����������� ���� ������ ������������.
        Vector2 choseDirection = menuInputHandler.chooseInput;

        // ����������� ����������� � ����.
        float angle = Mathf.Atan2(choseDirection.y, choseDirection.x) * Mathf.Rad2Deg;

        // ���������� ��������� �����������
        if (angle >= -45 && angle < 45)
        {
            // ������
            TakeValue(ItemType.Ammo);
        }
        else if (angle >= 45 && angle < 135)
        {
            // �����
            TakeValue(ItemType.Binoculars);
        }
        else if (angle >= -135 && angle < -45)
        {
            // ����
            // ������ ���������� ����� �� �������
        }
        else
        {
            // �����
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

    /// <summary>
    /// ������ ���� �� �������.
    /// </summary>
    /// <param name="chosenType"></param>
    void TakeValue(ItemType chosenType)
    {
        if (!items.ContainsKey(chosenType))
        {
            Debug.LogError($"���� {chosenType} ��������� � �������.");
            return;
        }

        if (items[chosenType] > 0)
        {
            items[chosenType] -= 1;
            
            // ����� ������ �� �����.
            itemSpawner.SpawnItem(chosenType);
        }
        else
        {
            // ���� ������� �������.
        }
    }
}
