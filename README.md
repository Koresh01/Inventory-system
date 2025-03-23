# Inventory-system
Система инвентаря. Unity 3D. URP project

# Задание

Реализовывать все в 3D.
* Предметы должны использовать физику и гравитацию ( rigidbody ).
* 3 условных объекта, каждый имеет свой конфигуратор ( со следующими полями: вес, название, идентификатор, тип ).
* Создать объект "рюкзак" в который будут помещаться предметы.
* Подбирать предметы можно мышкой и закидывая их в "рюкзак" ( используя Drag & Drop ) они должны быть помещены "внутрь"  и сохраниться.
* Каждый объект имеет разный тип.
* При наведении на "рюкзак", нажимая и не отпуская ЛКМ, отображается содержимое рюкзака ( простенькое UI ).
* При наведении на один из предметов ( все так же, не отпуская ЛКМ) и отпустив на нем ЛКМ, предмет "достается" из "рюкзака".
* Каждый ивент складывания/доставания предмета из/в "рюкзак" отправляется запрос на сервер, с идентификатором предмета и его событием.
* адрес сервера для отправки POST запроса:
https://wadahub.manerai.com/api/inventory/status
* ключ авторизации:
Bearer Token: "kPERnYcWAY46xaSy8CEzanosAgsWM84Nx7SKM4QBSqPq6c7StWfGxzhxPfDh8MaP"

response:
{"response":"success","status":"data received","data_submitted":<DATA_YOU_SENT>}

* Каждый ивент складывания/доставания сопровождается UnityEvent.
* Каждый тип объекта имеет свою уникальную позицию на UI рюкзака.
* Каждый тип объекта имеет свою уникальную позицию на модельке рюкзака ( должен прикрепляться на рюкзак ).
* Каждый объект плавно приснэпливается к своему месту на рюкзаке и так же плавно из него вынимается.
* Красивый и инкапсулированный код с использованием понятных комментариев.
* Чистота и порядок в проекте/иерархии.
* Опубликовать проект в общий доступ на GitHub для проверки.
* Опубликовать сборку игры на itch.io с возможностью теста в браузере (webGL) для проверки.

# Выполнил
## Что нового я извлек для себя.
В этой работе мне удалось сделать интерфес для всех gameObject, которые должны как либо реагировать на зажатие ПКМ.

Такими игровыми объектами являются

Items:
![image](https://github.com/user-attachments/assets/9540c6e0-a795-485d-9df4-79cc3513e174)

И рюкзак:

![image](https://github.com/user-attachments/assets/8221cff6-0964-4c2d-a8ee-e6c13a00ee31)

## Вкратце, как это работает
Вот интерфейс для всего, что должно иметь реацию на ПКМ:
```C#
using UnityEngine;

/// <summary>
/// Захватываемый объект.
/// </summary>
public interface IHoldable
{
    /// <summary>
    /// Начать удержание
    /// </summary>
    void StartHolding();
    /// <summary>
    /// Закончить удержание.
    /// </summary>
    void StopHolding();
}
```


Вот событие хватания:
![image](https://github.com/user-attachments/assets/36176c64-50d6-497c-8e4a-8ddac3eaa41a)

Вот как мы подписываемся на него:
```C#
// Drag & drop
playerInput.FirstPersonView.Grab.started += playerDirectionLookHandler.OnGrab;
playerInput.FirstPersonView.Grab.canceled += playerDirectionLookHandler.OnGrab;
```

А этот метод вызывает функции **StartHolding()** и **StopHolding** у **curGrabbleObj**. 
```C#
[Tooltip("То на что смотрит игрок.")]
[SerializeField] IHoldable curGrabbleObj; // наследник нашего интерфейса

...

/// <summary>
/// Обработчик события нажатия на кнопку взятия.
/// </summary>
/// <param name="context">Контекст возвращаемый из InputPlayerActions</param>
public void OnGrab(InputAction.CallbackContext context)
{
        if (context.started)
        {
            if (curGrabbleObj != null)
            {
                curGrabbleObj.StartHolding();
            }
        }
        else if (context.canceled)
        {
            if (curGrabbleObj != null)
            {
                curGrabbleObj.StopHolding();
                curGrabbleObj = null;
            }
        }
}
```

А в качестве curGrabbleObj *(текущего выбранного объекта)* могут выступать:

* Вещь, которую можно взять и переместить, зажав ПКМ:
```C#
using UnityEngine;

/// <summary>
/// Вещь
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

```

* Рюкзак(если держим на нем ПКМ, то появляется круговое меню)
```C#
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер рюкзака.
/// </summary>
public class Inventory : MonoBehaviour, IHoldable
{
    public Dictionary<ItemType, int> items = new Dictionary<ItemType, int>();

    [Header("Ссылки на зависимости:")]
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] MenuInputHandler menuInputHandler;
    [SerializeField] ItemSpawner itemSpawner;

    [SerializeField] GameObject inventoryPanel;

    private void Awake()
    {
        inventoryPanel.SetActive(false);
    }

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

    /// <summary>
    /// Делаем вывод что выбрал пользователь.
    /// </summary>
    void StopHoldingHandler()
    {
        // Направление куда указал пользователь.
        Vector2 choseDirection = menuInputHandler.chooseInput;

        // Преобразуем направление в угол.
        float angle = Mathf.Atan2(choseDirection.y, choseDirection.x) * Mathf.Rad2Deg;

        // Определяем ближайшее направление
        if (angle >= -45 && angle < 45)
        {
            // вправо
            TakeValue(ItemType.Ammo);
        }
        else if (angle >= 45 && angle < 135)
        {
            // вверх
            TakeValue(ItemType.Binoculars);
        }
        else if (angle >= -135 && angle < -45)
        {
            // вниз
            // Отмена доставания вещей из рюкзака
        }
        else
        {
            // влево
            TakeValue(ItemType.Heal);
        }
    }

    ...
    private void OnCollisionEnter(Collision collision)
    {
        Item item = collision.gameObject.GetComponent<Item>();
        if (item != null)
        {
            AddItem(item.itemType);
            Destroy(collision.gameObject);
        }
    }

    ...
}

```



## Фотографии законченной(почти всё смог сделать) работы:
Отмечу, что я использовал новую систему ввода Unity. Так что играть можно ещё и на джойстике. 
ПКМ - взаимодействие с предметами
WASD/space - перемещение/прыжок.

![image](https://github.com/user-attachments/assets/0ccb2b9d-8659-4e3b-804d-be3a16743a0e)
![image](https://github.com/user-attachments/assets/d4aca3d0-b32c-4f48-b104-e8c207f41d1b)

Вращаем мышку, с нажатой ПКМ и выбираем предмет, который хотим достать:
![image](https://github.com/user-attachments/assets/b182fe18-e79a-4b20-9c69-3e1ec1978c9a)

Вот как перемещаем предметы:
![image](https://github.com/user-attachments/assets/f2a3e1d6-c605-408c-bd65-ecf8526f4edf)

Вещи, которые мы достали из рюкзака оказываются вот тут:
![image](https://github.com/user-attachments/assets/00bb2cde-8e9b-413a-9558-99c85c8735c2)





