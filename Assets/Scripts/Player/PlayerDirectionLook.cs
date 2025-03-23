using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// ���������� �� ��� ������� �����, � �������� �������� ���������, ���� ����� ����� ���.
/// </summary>
public class PlayerDirectionLook : MonoBehaviour
{
    private Camera mainCamera;

    public UnityEvent OnStartLookAtItem;
    public UnityEvent OnStopLookAtItem;

    [Header("������ �� �������:")]
    [SerializeField] PointController pointController;



    [Header("������� ���������:")]
    
    [Tooltip("�� �� ��� ������� �����.")]
    [SerializeField] IHoldable curGrabbleObj;

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
            if (hit.collider.TryGetComponent(out IHoldable item))
            {
                // ����� �������� ���������� ��������� �������� (��������, ����� ���������)
                curGrabbleObj = item;
                lastHitTime = Time.time; // ��������� ����� ���������� ���������

                OnStartLookAtItem?.Invoke();
                return; // ����� �� ������, �.�. ������� ������
            }
        }

        // ���� ������ ������ �������, ��� hitTimeout, ���������� currentItem
        if (Time.time - lastHitTime > hitTimeout)
        {
            curGrabbleObj = null;
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
            if (curGrabbleObj != null)
            {
                curGrabbleObj.StartHolding();
            }
        }
        else if (context.canceled)
        {
            if (curGrabbleObj != null)
            {
                curGrabbleObj.StopHolding();
                curGrabbleObj = null;
            }
        }
    }
}
