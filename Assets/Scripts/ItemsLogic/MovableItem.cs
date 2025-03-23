using UnityEngine;

/// <summary>
/// Заставляет Item на сцене двигаться за followTarget. Висит на каждой Item на сцене.
/// </summary>
[AddComponentMenu("Custom/MovableItem (Контроллер следования за рукой)")]
public class MovableItem : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private bool isBeingDragged = false;
    [SerializeField, Tooltip("Transform руки персонажа.")] private Transform followTarget;

    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void StartDragging(Transform target)
    {
        isBeingDragged = true;
        followTarget = target;
        rb.useGravity = false;
        rb.isKinematic = true; // Отключаем физику для предмета
    }

    public void StopDragging()
    {
        isBeingDragged = false;
        followTarget = null;
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
