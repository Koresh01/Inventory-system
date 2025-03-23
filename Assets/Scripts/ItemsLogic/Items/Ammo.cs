using UnityEngine;

public class Ammo : MonoBehaviour, IItem
{
    [SerializeField] private Sprite icon;
    [SerializeField] private int weight;
    [SerializeField] private ItemType itemType;

    public Sprite Icon => icon;
    public int Weight => weight;
    public ItemType ItemType => itemType;
}
