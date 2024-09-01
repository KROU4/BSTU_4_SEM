// Подключение необходимых пространств имен
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Объявление класса CapsuleMovement, который наследуется от MonoBehaviour
public class CapsuleMovement : MonoBehaviour
{
    // Публичное поле для настройки скорости перемещения с помощью клавиатуры
    public float keyboardMoveSpeed = 1;
    // Публичное поле для настройки скорости перемещения с помощью мыши
    public float mouseMoveSpeed = 1;

    // Метод Start вызывается один раз при инициализации
    void Start()
    {
    }

    // Метод Update вызывается один раз за кадр
    void Update()
    {
        // Перемещение капсулы с помощью клавиатуры по горизонтальной и вертикальной оси
        transform.Translate(
            keyboardMoveSpeed * Input.GetAxis("Horizontal"), // Перемещение по оси X
            0, // Отсутствие перемещения по оси Y
            keyboardMoveSpeed * Input.GetAxis("Vertical") // Перемещение по оси Z
        );

        // Перемещение капсулы с помощью мыши по осям X и Y
        transform.Translate(
            mouseMoveSpeed * Input.GetAxis("Mouse X"), // Перемещение по оси X
            0, // Отсутствие перемещения по оси Y
            mouseMoveSpeed * Input.GetAxis("Mouse Y") // Перемещение по оси Z
        );
    }
}
