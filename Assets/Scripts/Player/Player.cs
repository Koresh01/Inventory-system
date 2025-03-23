using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody rb;
    private Transform cameraTransform;

    private ItemDragHandler itemDragHandler;

    [Header("Параметры игрока:")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private float joystickSensitivity = 1f;
    [SerializeField] private float maxLookAngle = 60f; // Ограничение угла камеры

    [Header("Состояние от устройств ввода:")]
    [SerializeField] Vector2 moveInput;
    [SerializeField] Vector2 lookInput;
    [SerializeField] float cameraPitch = 0f; // Текущий угол наклона камеры

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; // Блокируем курсор в центре экрана
        Cursor.visible = false; // Делаем его невидимым

        // Получаем зависимости
        itemDragHandler = GetComponentInChildren<ItemDragHandler>();

        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }

    private void OnEnable()
    {
        playerInput.Enable();

        // Перемещение
        playerInput.FirstPersonView.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.FirstPersonView.Move.canceled += ctx => moveInput = Vector2.zero;

        // Вращение камеры
        playerInput.FirstPersonView.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        playerInput.FirstPersonView.Look.canceled += ctx => lookInput = Vector2.zero;

        // Drag & drop
        playerInput.FirstPersonView.Grab.started += itemDragHandler.OnGrab;
        playerInput.FirstPersonView.Grab.canceled += itemDragHandler.OnGrab;
    }

    private void OnDisable()
    {
        playerInput.FirstPersonView.Move.performed -= ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.FirstPersonView.Move.canceled -= ctx => moveInput = Vector2.zero;

        playerInput.FirstPersonView.Look.performed -= ctx => lookInput = ctx.ReadValue<Vector2>();
        playerInput.FirstPersonView.Look.canceled -= ctx => lookInput = Vector2.zero;

        playerInput.FirstPersonView.Grab.started -= itemDragHandler.OnGrab;
        playerInput.FirstPersonView.Grab.canceled -= itemDragHandler.OnGrab;

        playerInput.Disable();
    }

    private void FixedUpdate()
    {
        MoveHandler();
        LookHandler();
    }

    void MoveHandler()
    {
        Vector3 move = transform.forward * moveInput.y + transform.right * moveInput.x;
        move *= moveSpeed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }

    void LookHandler()
    {
        float sensitivity = IsUsingMouse() ? mouseSensitivity : joystickSensitivity;

        // Поворот персонажа (влево-вправо)
        transform.Rotate(Vector3.up * lookInput.x * sensitivity * Time.deltaTime);

        // Поворот камеры (вверх-вниз) с ограничением
        cameraPitch -= lookInput.y * sensitivity * Time.deltaTime;
        cameraPitch = Mathf.Clamp(cameraPitch, -maxLookAngle, maxLookAngle);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
    }

    private bool IsUsingMouse()
    {
        return Mouse.current != null && Mouse.current.delta.ReadValue() != Vector2.zero;
    }
}
