using UnityEngine;

/// <summary>
/// ����� ����� �� ���� � ���������� ��.
/// </summary>
public class Item : MonoBehaviour, IHoldable
{
    [Header("���� ���������� � ����:")]
    public Sprite icon;
    public int weight;
    public ItemType itemType;

    [Header("������� ���������:")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private bool isBeingDragged = false;
    [SerializeField, Tooltip("Transform ���� ���������.")] private Transform followTarget;

    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        followTarget = FindAnyObjectByType<PlayerDirectionLook>().transform;
    }

    public void StartHolding()
    {
        isBeingDragged = true;
        rb.useGravity = false;
        rb.isKinematic = true; // ��������� ������ ��� ��������
    }

    public void StopHolding()
    {
        isBeingDragged = false;
        rb.useGravity = true;
        rb.isKinematic = false; // �������� ������ �������
    }

    private void Update()
    {
        if (isBeingDragged && followTarget != null)
        {
            transform.position = followTarget.position;
        }
    }
}
