using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// Контроллер drag & drop системы.
/// </summary>
public class ItemDragHandler : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField, Tooltip("Transform руки игрока.")] private Transform holdPosition; // Позиция, куда переносим предмет

    public UnityEvent OnStartLookAtItem;
    public UnityEvent OnStopLookAtItem;

    [Header("Ссылки на скрипты:")]
    [SerializeField] PointController pointController;

    [Header("Текущее состояние:")]
    [SerializeField, Tooltip("Текущая деталь на которую смотрим.")] private MovableItem currentItem;

    private float lastHitTime = 0f; // Время последнего успешного попадания Raycast
    private float hitTimeout = 0.3f; // Тайм-аут для проверки успешного попадания Raycast

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
            if (hit.collider.TryGetComponent(out MovableItem item))
            {
                // Можно добавить визуальное выделение предмета (например, смену материала)
                currentItem = item;
                lastHitTime = Time.time; // Обновляем время последнего попадания

                OnStartLookAtItem?.Invoke();
                return; // Вышли из метода, т.к. предмет найден
            }
        }

        // Если прошло больше времени, чем hitTimeout, сбрасываем currentItem
        if (Time.time - lastHitTime > hitTimeout)
        {
            currentItem = null;
            OnStopLookAtItem?.Invoke();
        }
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
