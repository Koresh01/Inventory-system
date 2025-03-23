using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// ���������� drag & drop �������.
/// </summary>
public class ItemDragHandler : MonoBehaviour
{
    [SerializeField, Tooltip("Transform ���� ������.")] private Transform holdPosition; // �������, ���� ��������� �������

    private Camera mainCamera;
    [SerializeField, Tooltip("������� ������ �� ������� �������.")] private DraggableItem currentItem;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        CheckForItemUnderCursor();
    }

    /// <summary>
    /// ��������� ��������� �� �������� ��� ��������.
    /// </summary>
    private void CheckForItemUnderCursor()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit, 3f))
        {
            if (hit.collider.TryGetComponent(out DraggableItem item))
            {
                // ����� �������� ���������� ��������� �������� (��������, ����� ���������)
                currentItem = item;
                return; // ����� �� ������, �.�. ������� ������
            }
        }

        // ���� ������ �� ������� ��� ������� �� DraggableItem � ���������� currentItem
        currentItem = null;
    }


    /// <summary>
    /// ���������� ������� ������� �� ������ ������.
    /// </summary>
    /// <param name="context">�������� ������������ �� InputPlayerActions</param>
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
