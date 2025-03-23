using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

/// <summary>
/// Обработчик устройств ввода пользователя. КОГДА ОН В РЕЖИМЕ КРУГОВОГО МЕНЮ
/// </summary>
public class MenuInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    public Vector2 chooseInput;

    [Tooltip("Стрелка выбора элементов из рюкзака")]
    [SerializeField] Image dirArrowImg;
    RectTransform dirArrowRect;

    private void Awake()
    {
        playerInput = new PlayerInput();
        dirArrowRect = dirArrowImg.GetComponent<RectTransform>();  // Получаем RectTransform компонента стрелки
    }

    private void OnEnable()
    {
        playerInput.Enable();

        playerInput.MenuControl.RoundValue.performed += ctx => chooseInput = ctx.ReadValue<Vector2>().normalized;
        // playerInput.MenuControl.RoundValue.canceled += ctx => chooseInput = Vector2.zero;
    }

    private void OnDisable()
    {
        playerInput.MenuControl.RoundValue.performed -= ctx => chooseInput = ctx.ReadValue<Vector2>().normalized;
        // playerInput.MenuControl.RoundValue.canceled -= ctx => chooseInput = Vector2.zero;

        playerInput.Disable();
    }

    private void Update()
    {
        // Преобразуем направление в угол.
        float angle = Mathf.Atan2(chooseInput.y, chooseInput.x) * Mathf.Rad2Deg;

        // Поворачиваем стрелку.
        dirArrowRect.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}
