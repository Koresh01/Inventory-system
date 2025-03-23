using UnityEngine;
using UnityEngine.UI;

public class RoundMenuView : MonoBehaviour 
{
    [SerializeField] Inventory inventory;

    [SerializeField] Text binocularsCount;
    [SerializeField] Text ammosCount;
    [SerializeField] Text healsCount;

    private void OnEnable()
    {
        InitCounts();
    }

    private void OnDisable()
    {
        
    }

    void InitCounts()
    {
        foreach (var item in inventory.items) {
            switch (item.Key)
            {
                case ItemType.Binoculars:
                    binocularsCount.text = item.Value.ToString();
                    break;
                case ItemType.heal:
                    healsCount.text = (item.Value.ToString());
                    break;
                case ItemType.ammo:
                    ammosCount.text = (item.Value.ToString());
                    break;
            }
        }
    }
}
