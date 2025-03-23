using UnityEngine;

/// <summary>
/// Заставляет Item на сцене двигаться за followTarget. Висит на каждой Item на сцене.
/// </summary>
public class DraggableItem : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private bool isBeingDragged = false;
    [SerializeField] private Transform followTarget;

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
            transform.position = Vector3.Lerp(transform.position, followTarget.position, Time.deltaTime * 20f);
        }
    }
}
