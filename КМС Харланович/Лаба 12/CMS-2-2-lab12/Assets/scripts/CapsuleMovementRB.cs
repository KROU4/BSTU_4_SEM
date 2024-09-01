// Подключение необходимых пространств имен
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Объявление класса CapsuleMovementRB, который наследуется от MonoBehaviour
public class CapsuleMovementRB : MonoBehaviour
{
    // Публичное поле для настройки скорости перемещения с помощью клавиатуры
    public float keyboardMoveSpeed = 1;
    // Публичное поле для настройки скорости перемещения с помощью мыши
    public float mouseMoveSpeed = 1;
    // Публичное поле для настройки силы прыжка
    public float jumpPower = 1;

    // Приватное поле для хранения ссылки на компонент Rigidbody
    Rigidbody rb;

    // Метод Start вызывается один раз при инициализации
    void Start()
    {
        // Получение и сохранение ссылки на компонент Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Метод Update вызывается один раз за кадр
    void Update()
    {
        // Создание нового вектора скорости и установка его значений в ноль
        Vector3 newVelocity = Vector3.zero;

        // Добавление к вектору скорости значений перемещения с помощью клавиатуры
        newVelocity += new Vector3(
            keyboardMoveSpeed * Input.GetAxis("Horizontal"), // Перемещение по оси X
            0, // Отсутствие перемещения по оси Y
            keyboardMoveSpeed * Input.GetAxis("Vertical") // Перемещение по оси Z
        );
        // Добавление к вектору скорости значений перемещения с помощью мыши
        newVelocity += new Vector3(
            mouseMoveSpeed * Input.GetAxis("Mouse X"), // Перемещение по оси X
            0, // Отсутствие перемещения по оси Y
            mouseMoveSpeed * Input.GetAxis("Mouse Y") // Перемещение по оси Z
        );
        // Проверка нажатия клавиши пробела для прыжка
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Добавление силы прыжка к вектору скорости по оси Y
            newVelocity.y += jumpPower;
        }
        // Сохранение текущей вертикальной скорости объекта
        newVelocity.y += rb.velocity.y;

        // Применение нового вектора скорости к компоненту Rigidbody
        rb.velocity = newVelocity;
    }
}
