using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Обработчик устройств ввода пользователя.
/// </summary>
public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;

    [Header("Сам игрок:")]
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform playerTransform;
    [SerializeField] bool isGrounded;

    private Transform cameraTransform;

    [Header("Ссылки на зависимости:")]
    [SerializeField] PlayerDirectionLook playerDirectionLookHandler;

    [Header("Параметры игрока:")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private float joystickSensitivity = 1f;
    [SerializeField] private float maxLookAngle = 60f; // Ограничение угла камеры
    [SerializeField] private float jumpForce = 10f; // Сила прыжка

    [Header("Состояние от устройств ввода:")]
    public bool isPaused = false;
    [SerializeField] Vector2 moveInput;
    [SerializeField] Vector2 lookInput;
    [SerializeField] float cameraPitch = 0f; // Текущий угол наклона камеры


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; // Блокируем курсор в центре экрана
        Cursor.visible = false; // Делаем его невидимым

        playerInput = new PlayerInput();
        cameraTransform = Camera.main.transform;
    }

    private void OnEnable()
    {
        playerInput.Enable();

        // Перемещение
        playerInput.FirstPersonView.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.FirstPersonView.Move.canceled += ctx => moveInput = Vector2.zero;

        // Прыжок
        playerInput.FirstPersonView.Jump.performed += Jump;

        // Вращение камеры
        playerInput.FirstPersonView.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        playerInput.FirstPersonView.Look.canceled += ctx => lookInput = Vector2.zero;

        // Drag & drop
        playerInput.FirstPersonView.Grab.started += playerDirectionLookHandler.OnGrab;
        playerInput.FirstPersonView.Grab.canceled += playerDirectionLookHandler.OnGrab;
    }

    private void OnDisable()
    {
        playerInput.FirstPersonView.Move.performed -= ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.FirstPersonView.Move.canceled -= ctx => moveInput = Vector2.zero;

        playerInput.FirstPersonView.Look.performed -= ctx => lookInput = ctx.ReadValue<Vector2>();
        playerInput.FirstPersonView.Look.canceled -= ctx => lookInput = Vector2.zero;

        playerInput.FirstPersonView.Grab.started -= playerDirectionLookHandler.OnGrab;
        playerInput.FirstPersonView.Grab.canceled -= playerDirectionLookHandler.OnGrab;

        playerInput.Disable();
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            MoveHandler();
            LookHandler();
            CheckGroundedStatus(); // Проверка на приземление
        }
        else
            rb.velocity = Vector3.zero;
    }

    void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded) // Прыжок только если на земле
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void MoveHandler()
    {
        if (!isGrounded) return;

        Vector3 move = playerTransform.forward * moveInput.y + playerTransform.right * moveInput.x;
        move *= moveSpeed;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z); // Контролируем движение по оси X и Z, но сохраняем вертикальную скорость
    }

    void LookHandler()
    {
        float sensitivity = IsUsingMouse() ? mouseSensitivity : joystickSensitivity;

        // Поворот персонажа (влево-вправо)
        playerTransform.Rotate(Vector3.up * lookInput.x * sensitivity * Time.deltaTime);

        // Поворот камеры (вверх-вниз) с ограничением
        cameraPitch -= lookInput.y * sensitivity * Time.deltaTime;
        cameraPitch = Mathf.Clamp(cameraPitch, -maxLookAngle, maxLookAngle);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
    }

    private bool IsUsingMouse()
    {
        return Mouse.current != null && Mouse.current.delta.ReadValue() != Vector2.zero;
    }

    // Проверка на приземление
    private void CheckGroundedStatus()
    {
        isGrounded = Physics.Raycast(playerTransform.position, Vector3.down, 2f); // Проверяем, есть ли земля под игроком
    }
}
