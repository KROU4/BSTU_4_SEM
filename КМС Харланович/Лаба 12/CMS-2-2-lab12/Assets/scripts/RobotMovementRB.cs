// Подключение необходимых пространств имен
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Объявление класса RobotMovementRB, который наследуется от MonoBehaviour
public class RobotMovementRB : MonoBehaviour
{
    // Публичное поле для настройки скорости перемещения робота
    public float movementSpeed = 1;

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

        // Проверка нажатия клавиши I для перемещения вперед по оси Z
        if (Input.GetKey(KeyCode.I))
        {
            newVelocity.z += movementSpeed;
        }
        // Проверка нажатия клавиши J для перемещения влево по оси X
        if (Input.GetKey(KeyCode.J))
        {
            newVelocity.x -= movementSpeed;
        }
        // Проверка нажатия клавиши K для перемещения назад по оси Z
        if (Input.GetKey(KeyCode.K))
        {
            newVelocity.z -= movementSpeed;
        }
        // Проверка нажатия клавиши L для перемещения вправо по оси X
        if (Input.GetKey(KeyCode.L))
        {
            newVelocity.x += movementSpeed;
        }
        // Сохранение текущей вертикальной скорости объекта
        newVelocity.y += rb.velocity.y;

        // Применение нового вектора скорости к компоненту Rigidbody
        rb.velocity = newVelocity;
    }
}
