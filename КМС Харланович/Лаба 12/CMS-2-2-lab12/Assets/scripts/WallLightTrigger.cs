// Подключение необходимых пространств имен
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Объявление класса WallLightTrigger, который наследуется от MonoBehaviour
public class WallLightTrigger : MonoBehaviour
{
    // Ссылка на источник света
    public Light pointLight;
    // Список имен объектов, для которых триггер будет активным
    public List<string> detectableObjects = new List<string>();

    // Метод Start вызывается один раз при инициализации
    void Start()
    {
    }

    // Метод Update вызывается один раз за кадр
    void Update()
    {
    }

    // Метод, вызываемый при входе другого объекта в триггер
    void OnTriggerEnter(Collider other)
    {
        // Проверка, содержится ли имя объекта в списке detectableObjects
        if (!detectableObjects.Contains(other.name))
        {
            return; // Если не содержится, выход из метода
        }
        // Включение источника света
        pointLight.enabled = true;
    }

    // Метод, вызываемый при выходе другого объекта из триггера
    void OnTriggerExit(Collider other)
    {
        // Проверка, содержится ли имя объекта в списке detectableObjects
        if (!detectableObjects.Contains(other.name))
        {
            return; // Если не содержится, выход из метода
        }
        // Выключение источника света
        pointLight.enabled = false;
    }
}
