using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Custom/(Логика точки посреди эрана)")]
public class PointController : MonoBehaviour
{
    ItemDragHandler itemDragHandler;

    Image currentPointImg;
    [SerializeField] Sprite standart;
    [SerializeField] Sprite drag;

    private void Awake()
    {
        currentPointImg = GetComponent<Image>();
    }
    public void SetDrag()
    {
        currentPointImg.sprite = drag;
    }

    public void SetStandart()
    {
        currentPointImg.sprite = standart;
    }
}
