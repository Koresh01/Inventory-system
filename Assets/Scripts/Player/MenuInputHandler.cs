using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Обработчик устройств ввода пользователя. КОГДА ОН В РЕЖИМЕ КРУГОВОГО МЕНЮ
/// </summary>
public class MenuInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    public Vector2 chooseInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }
    private void OnEnable()
    {
        playerInput.Enable();

        playerInput.MenuControl.RoundValue.performed += ctx => chooseInput = ctx.ReadValue<Vector2>();
        playerInput.MenuControl.RoundValue.canceled += ctx => chooseInput = Vector2.zero;
    }

    private void OnDisable()
    {
        playerInput.MenuControl.RoundValue.performed -= ctx => chooseInput = ctx.ReadValue<Vector2>();
        playerInput.MenuControl.RoundValue.canceled -= ctx => chooseInput = Vector2.zero;

        playerInput.Disable();
    }
}