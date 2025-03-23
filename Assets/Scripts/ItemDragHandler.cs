using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// ���������� drag & drop �������.
/// </summary>
public class ItemDragHandler : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField, Tooltip("Transform ���� ������.")] private Transform holdPosition; // �������, ���� ��������� �������

    public UnityEvent OnStartLookAtItem;
    public UnityEvent OnStopLookAtItem;

    [Header("������ �� �������:")]
    [SerializeField] PointController pointController;

    [Header("������� ���������:")]
    [SerializeField, Tooltip("������� ������ �� ������� �������.")] private MovableItem currentItem;

    private float lastHitTime = 0f; // ����� ���������� ��������� ��������� Raycast
    private float hitTimeout = 0.3f; // ����-��� ��� �������� ��������� ��������� Raycast

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
            if (hit.collider.TryGetComponent(out MovableItem item))
            {
                // ����� �������� ���������� ��������� �������� (��������, ����� ���������)
                currentItem = item;
                lastHitTime = Time.time; // ��������� ����� ���������� ���������

                OnStartLookAtItem?.Invoke();
                return; // ����� �� ������, �.�. ������� ������
            }
        }

        // ���� ������ ������ �������, ��� hitTimeout, ���������� currentItem
        if (Time.time - lastHitTime > hitTimeout)
        {
            currentItem = null;
            OnStopLookAtItem?.Invoke();
        }
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
