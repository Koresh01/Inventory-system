using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Контроллер drag & drop системы.
/// </summary>
public class ItemDragHandler : MonoBehaviour
{
    [SerializeField, Tooltip("Transform руки игрока.")] private Transform holdPosition; // Позиция, куда переносим предмет

    private Camera mainCamera;
    [SerializeField, Tooltip("Текущая деталь на которую смотрим.")] private DraggableItem currentItem;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        CheckForItemUnderCursor();
    }

    /// <summary>
    /// Проверяет находится ли деталька под курсором.
    /// </summary>
    private void CheckForItemUnderCursor()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit, 3f))
        {
            if (hit.collider.TryGetComponent(out DraggableItem item))
            {
                // Можно добавить визуальное выделение предмета (например, смену материала)
                currentItem = item;
                return; // Вышли из метода, т.к. предмет найден
            }
        }

        // Если ничего не найдено или предмет не DraggableItem — сбрасываем currentItem
        currentItem = null;
    }


    /// <summary>
    /// Обработчик события нажатия на кнопку взятия.
    /// </summary>
    /// <param name="context">Контекст возвращаемый из InputPlayerActions</param>
    public void OnGrab(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (currentItem != null)
            {
                currentItem.StartDragging(holdPosition);
            }
        }
        else if (context.canceled)
        {
            if (currentItem != null)
            {
                currentItem.StopDragging();
                currentItem = null;
            }
        }
    }
}
