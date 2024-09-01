// Подключение необходимых пространств имен
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Объявление класса CubeScript, который наследуется от MonoBehaviour и реализует интерфейс IPointerClickHandler
public class CubeScript : MonoBehaviour, IPointerClickHandler
{

    // Метод Start вызывается один раз при инициализации
    void Start()
    {
    }

    // Метод Update вызывается один раз за кадр
    void Update()
    {
    }

    // Реализация метода интерфейса IPointerClickHandler, который вызывается при клике на объект
    public void OnPointerClick(PointerEventData eventData)
    {
        // Изменение цвета материала объекта на случайный цвет
        gameObject.GetComponent<Renderer>().material.color = new Color(
            Random.Range(0f, 1f), // Случайное значение для красного канала
            Random.Range(0f, 1f), // Случайное значение для зеленого канала
            Random.Range(0f, 1f)  // Случайное значение для синего канала
        );

        // Определение силы, с которой будет приложена сила к объекту
        int force = 1000;

        // Получение позиции точки нажатия в мировых координатах
        Vector3 target = eventData.pointerPressRaycast.worldPosition;
        // Получение позиции камеры в мировых координатах
        Vector3 camera = Camera.main.transform.position;
        // Вычисление нормализованного вектора от камеры до точки нажатия
        Vector3 distance = (target - camera).normalized;
        // Вычисление силы, которая будет приложена к объекту
        Vector3 collid = distance * force;

        // Применение силы к объекту в точке нажатия
        gameObject.GetComponent<Rigidbody>().AddForceAtPosition(collid, target);
    }
}
