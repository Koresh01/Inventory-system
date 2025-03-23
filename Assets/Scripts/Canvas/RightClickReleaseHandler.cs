using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RightClickReleaseHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent OnRightClickUp;

    private bool isPointerOver = false;

    private void Update()
    {
        if (Input.GetMouseButtonUp(1) && isPointerOver) // 1 - œ Ã
        {
            OnRightClickUp?.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
    }
}
