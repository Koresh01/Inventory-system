using UnityEngine;

public class Binoculars : MonoBehaviour, IItem
{
    [SerializeField] private Sprite icon;
    [SerializeField] private int weight;
    [SerializeField] private string itemName;

    public Sprite Icon => icon;
    public int Weight => weight;
    public string Name => itemName;
}
