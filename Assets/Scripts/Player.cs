using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody rb;
    [SerializeField] private float speed = 5f;

    private Vector2 moveInput; // Храним текущее направление движения

    private void Awake()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.FirstPersonView.MoveDelta.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.FirstPersonView.MoveDelta.canceled += ctx => moveInput = Vector2.zero; // Останавливаем при отпускании клавиш
    }

    private void OnDisable()
    {
        playerInput.FirstPersonView.MoveDelta.performed -= ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.FirstPersonView.MoveDelta.canceled -= ctx => moveInput = Vector2.zero;
        playerInput.Disable();
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) * speed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }
}
