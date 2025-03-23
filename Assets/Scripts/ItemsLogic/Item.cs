using UnityEngine;

/// <summary>
/// Класс висит на вещи и определяет ёё.
/// </summary>
public class Item : MonoBehaviour, IHoldable
{
    [Header("Мета информация о вещи:")]
    public Sprite icon;
    public int weight;
    public ItemType itemType;

    [Header("Текущее состояние:")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private bool isBeingDragged = false;
    [SerializeField, Tooltip("Transform руки персонажа.")] private Transform followTarget;

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
        rb.isKinematic = true; // Отключаем физику для предмета
    }

    public void StopHolding()
    {
        isBeingDragged = false;
        rb.useGravity = true;
        rb.isKinematic = false; // Включаем физику обратно
    }

    private void Update()
    {
        if (isBeingDragged && followTarget != null)
        {
            transform.position = followTarget.position;
        }
    }
}
