# Inventory-system
Система инвентаря. Unity 3D. URP project

# Когда использовать интерфейсы в C#?
Скрипт направления взгляда игрока использует луч для определения того, на какой объект он смотрит, сохраняя его в переменную ```curItem```:

![image](https://github.com/user-attachments/assets/46801063-dbcf-4366-840c-b870a2e565c8)

```C#
    private void Update()
    {
        CheckForItemUnderCursor();
    }

    private void CheckForItemUnderCursor()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit, 3f))
        {
            if (hit.collider.TryGetComponent(out IHoldable item))
            {
                // Игрок смотрит на предмет item:
                curItem = item;    // <--------------------------------

                OnStartLookAtItem?.Invoke();
                return;
            }
        }
    }
```

При нажатии правой кнопки мыши вызывается метод ```StartHolding()``` у ```curItem```, а при отпускании — ```StopHolding()```, посредством вызова функции ```OnGrab()```:
```C#
    public void OnGrab(InputAction.CallbackContext context)
    {
        if (context.started)
            curItem.StartHolding();    // логика начала удержания
        else if (context.canceled)
        {
            curItem.StopHolding();    // логика конца удержания
            curItem = null;
        }
    }
```
Если вы хотите использовать разные игровые объекты (в качестве ```curItem```) с *РАЗЛИЧНОЙ РЕАЛИЗАЦИЕЙ ЛОГИКИ УДЕРЖАНИЯ*, удобно создать интерфейс ```IHoldable```, который требует наличия методов ```StartHolding()``` и ```StopHolding()```.

```C#
public interface IHoldable
{
    void StartHolding();
    void StopHolding();
}

```

Таким образом, вы можете хранить ```curItem``` как ```IHoldable```:

```C#
[Tooltip("То на что смотрит игрок.")]
[SerializeField] IHoldable curItem;
```

В качестве ```curItem``` может выступать ```Item```:
Удержание для ```Item``` - это перетаскивание.
![image](https://github.com/user-attachments/assets/66a0ee7b-cb88-4812-a28e-5baf253bb7df)

![image](https://github.com/user-attachments/assets/cfe5cf02-3f0a-40d9-97e7-b1a3ccf99e89)

```C#
using UnityEngine;

/// <summary>
/// Контроллер следования Item за рукой.
/// </summary>
public class Item : MonoBehaviour, IHoldable
{
    // поля класса ...

    // ---------------------- Реализация интерфейса IHoldable ----------------------
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
    // -----------------------------------------------------------------------------
    private void Update()
    {
        if (isBeingDragged && followTarget != null)
        {
            transform.position = followTarget.position;
        }
    }
}
```

А ещё я захотел сделать инвентарь, который тоже должен реагировать на *УДЕРЖАНИЕ*, только *УЖЕ ПО ДРУГОМУ*:
Удержание для ```Inventory``` - это круговое меню выбора предмета, который хотим достать.
![image](https://github.com/user-attachments/assets/a0146b3b-68df-4d74-b92c-0e95e2458ea3)

![image](https://github.com/user-attachments/assets/a80ecf75-6115-4114-99f7-2fbf59542d24)

```C#
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер рюкзака.
/// </summary>
public class Inventory : MonoBehaviour, IHoldable
{
    // поля класса ...

    // ---------------------- Реализация интерфейса IHoldable ----------------------
    public void StartHolding()
    {
        inventoryPanel.SetActive(true);
        playerInputHandler.isPaused = true;
    }

    public void StopHolding()
    {
        inventoryPanel.SetActive(false);
        playerInputHandler.isPaused = false;

        StopHoldingHandler();
    }
    // -----------------------------------------------------------------------------
    }
}

```
Очевидно, что если появятся новые игровые сущности, которые должны реагировать на удержание, то функцию ```OnGrab()``` менять не прийдётся.
![image](https://github.com/user-attachments/assets/b0a04ec3-3a8b-46e0-95b9-a294ec408723)
